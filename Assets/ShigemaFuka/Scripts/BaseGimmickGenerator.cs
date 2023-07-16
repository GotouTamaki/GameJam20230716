using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ギミックを生成する
/// 破棄はギミック自身で行う
/// </summary>
public class BaseGimmickGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("インターバル")] float _interval = 20f;
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
