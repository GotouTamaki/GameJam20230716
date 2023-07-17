using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChochinGeneretor : MonoBehaviour
{
    [SerializeField, Header("�G�̃I�u�W�F�N�g")] GameObject _tyotin = null;
    [SerializeField, Header("�ŏ��̃C���^�[�o��")] float _startInterval = 1f;
    [SerializeField, Header("�񓔂̃{�C�X")] AudioClip _chochin = null;
    [SerializeField, Header("�{�C�X�̃{�����[��")] float _volume = 1.0f;
    [SerializeField, Header("�ŏ��C���^�[�o��"), Range(5, 8)] float _minInterval = 1f;
    [SerializeField, Header("�ő�C���^�[�o��"), Range(5, 8)] float _maxInterval = 1f;
    [SerializeField, Header("�C���^�[�o��"), Range(5, 8)] float _interval = 1f;   

    // �e�평����
    GameManager gameManager = null;
    AudioSource _audioSource = null;

    /// <summary>�ŏ��̑ҋ@���Ԃ̏���</summary>
    IEnumerator Start()
    {
        gameManager = GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        //Debug.Log("start");
        enabled = false;
        yield return new WaitForSeconds(_startInterval);
        enabled = true;
        //Debug.Log("EndStart");
        StartCoroutine(TyotinGene(_interval));
    }

    /// <summary>�񓔂̃W�F�l���[�^�[</summary>
    /// <param name="interval">�����̃C���^�[�o��</param>
    IEnumerator TyotinGene(float interval)
    {
        yield return new WaitForSeconds(interval);

        // �񓔂̏o���̉ۂ̔���
        if (GameManager.Instance._isChouchinSpawnning == false)
        {
            //Debug.Log("�񓔃X�|�[��");
            GameObject enemy = Instantiate(_tyotin, this.transform.position, this.transform.rotation);
            _audioSource.PlayOneShot(_chochin, _volume);
            GameManager.Instance._isChouchinSpawnning = true;
        }

        // �C���^�[�o���������_���ɂ���
        _interval = Random.Range(_minInterval, _maxInterval);
        //Debug.Log(_interval);
        StartCoroutine(TyotinGene(_interval));
    }
}
