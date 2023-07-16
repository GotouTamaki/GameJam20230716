using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J�n30�b�Ԃ́A���ʂƒ񓔂̐����X�N���v�g���A�N�e�B�u�ɂ��� 
/// </summary>
public class GeneratorController : MonoBehaviour
{
    //[SerializeField, Tooltip("�M�~�b�N�g�p")] bool _isActive;
    [SerializeField, Tooltip("�g�p�J�n����")] float _startTime = 30f; 
    [SerializeField] float _time;
    [SerializeField] TyotinGenerator _tyotinGenerator;
    [SerializeField] OmenGenerator _omenGenerator;
    [SerializeField, Tooltip("�Ďg�p�h�~")] bool canUseThis; 
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
