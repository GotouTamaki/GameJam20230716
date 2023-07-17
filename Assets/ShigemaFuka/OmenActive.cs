using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmenActive : MonoBehaviour
{
    [SerializeField] GameObject _omen;
    float _time;
    [SerializeField] float _interval;
    [SerializeField, Tooltip("�����Ă���̍Đ����܂ł̍ŏ��l")] int _min;
    [SerializeField, Tooltip("�����Ă���̍Đ����܂ł̍ő�l")] int _max;
    [SerializeField, Tooltip("�A�j���[�V�����̐�������")] float _lifeTime = 5f;
    float _animTime;

    private void Start()
    {
        //_omen = GetComponent<GameObject>();
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _interval && GameManager.Instance._isOmenSpawnnig == false)
        {
            _omen.SetActive(true);
            GameManager.Instance._isOmenSpawnnig = true;
        }
        if (GameManager.Instance._isOmenSpawnnig == true)
        {
            _animTime += Time.deltaTime;
        }
        if (_animTime > _lifeTime)
        {
            Debug.Log(_animTime);
            _animTime = 0;
            _time = 0;
            _omen.SetActive(false);
            GameManager.Instance._isOmenSpawnnig = false;
            _interval = Random.Range(_min, _max + 1);
        }
    }
}