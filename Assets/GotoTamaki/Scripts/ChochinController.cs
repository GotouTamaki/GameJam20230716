using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChochinController : MonoBehaviour
{
    [SerializeField, Header("����������")] AudioClip _hit = null;
    [SerializeField, Header("�񓔂̃{�C�X")] AudioClip _chochin = null;
    [SerializeField, Header("�����������{�����[��")] float __hitvolume = 1.0f;
    [SerializeField, Header("�{�C�X�̃{�����[��")] float __chochinVolume = 1.0f;

    // �e�평����
    AudioSource _audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        // 5�b��ɌĂяo��
        Invoke(nameof(ChochinDestroy), 5f);
    }

    // �񓔂̐���
    void ChochinDestroy()
    {
        GameManager.Instance._isChouchinSpawnning = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.PlayOneShot(_hit, __hitvolume);
        _audioSource.PlayOneShot(_chochin, __chochinVolume);
    }
}
