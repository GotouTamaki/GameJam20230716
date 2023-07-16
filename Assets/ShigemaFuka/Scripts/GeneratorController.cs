using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 開始30秒間は、お面と提灯の生成スクリプトを非アクティブにする 
/// </summary>
public class GeneratorController : MonoBehaviour
{
    //[SerializeField, Tooltip("ギミック使用")] bool _isActive;
    [SerializeField, Tooltip("使用開始時間")] float _startTime = 30f; 
    [SerializeField] float _time;
    [SerializeField] TyotinGenerator _tyotinGenerator;
    [SerializeField] OmenGenerator _omenGenerator;
    [SerializeField, Tooltip("再使用防止")] bool canUseThis; 
    void Start()
    {
        _time = 0;
        _tyotinGenerator.enabled = false;
        _omenGenerator.enabled = false;
        canUseThis = true; 
    }

    void Update()
    {
        if (canUseThis)
            _time += Time.deltaTime; 
        if(_time > _startTime && canUseThis)
        {
            _tyotinGenerator.enabled = true;
            _omenGenerator.enabled = true;
            canUseThis = false; 
        }
    }
}
