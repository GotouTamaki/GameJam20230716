using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �M�~�b�N�𐶐�����
/// �j���̓M�~�b�N���g�ōs��
/// </summary>
public class BaseGimmickGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�C���^�[�o��")] float _interval = 20f;
    [SerializeField] float _time;
    [SerializeField] GameObject _prefab;

    void Start()
    {

    }

    void Update()
    {
        _time += Time.deltaTime;

        if (_time > _interval)
        {
            Instantiate(_prefab);
            _time = 0;
        }
    }
}
