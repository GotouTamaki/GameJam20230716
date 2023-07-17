using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ʂ̕\��
/// �J�n���b�̓M�~�b�N����������Ȃ�
/// ���b�o�ߌ�́A�ϓ�����C���^�[�o�������ɐ��������
/// 
/// </summary>
public class OmenActive : MonoBehaviour
{
    [SerializeField, Tooltip("�g�p�J�n����")] float _startTime = 30f; 
    [SerializeField, Tooltip("���ʂ̃I�u�W�F�N�g")] GameObject _omen = default;
    [Tooltip("�o�ߎ���")] float _time = 0;
    [SerializeField, Tooltip("�ϓ����鐶���C���^�[�o��")] float _interval = 0;
    [SerializeField, Tooltip("�����Ă���̍Đ����܂ł̍ŏ��l")] int _min = 0;
    [SerializeField, Tooltip("�����Ă���̍Đ����܂ł̍ő�l")] int _max = 0;
    [SerializeField, Tooltip("�A�j���[�V�����̐�������")] float _lifeTime = 5f;
    [Tooltip("�A�j���[�V������\�����邽�߂̎��Ԍo��")] float _animTime = 0;
    [SerializeField] float _timeCount = 0;
    [SerializeField, Tooltip("�Ďg�p�h�~")] bool canUseGimmick = default;
    [SerializeField] AudioSource _audioSource = default; 
    void Update()
    {
        _timeCount += Time.deltaTime;
        _time += Time.deltaTime;

        // �Q�[���J�n����u_startTime�v�b�Ԃ̓M�~�b�N�𐶐��s�ɂ��� 
        if (_time > _startTime && !canUseGimmick)
        {
            canUseGimmick = true;
            _time = 0;
        }
        if (canUseGimmick)
        {
            // �C���^�[�o�����o�߂����琶��  ���񓔂Ƃ̓��������h�~�̂��߂̃t���O�i�����ł��ĂȂ��j
            if (_time > _interval && GameManager.Instance._isOmenSpawnnig == false)
            {
                _omen.SetActive(true); 
                _audioSource.Play(); 
                GameManager.Instance._isOmenSpawnnig = true;
            }
            // �������Ă���J�E���g�_�E��
            if (GameManager.Instance._isOmenSpawnnig == true)
            {
                _animTime += Time.deltaTime;
            }
            // �u_lifeTime�v�b�o�߂�����A�j���[�V�������I�u�W�F�N�g���A�N�e�B�u  
            if (_animTime > _lifeTime)
            {
                Debug.Log(_animTime);
                _animTime = 0;
                _time = 0;
                _omen.SetActive(false);
                GameManager.Instance._isOmenSpawnnig = false;
                // �����̃C���^�[�o�����u_min�`_max�v�̊ԂŃ����_���ɐݒ肷�� 
                _interval = Random.Range(_min, _max + 1);
            }
        }
    }
}