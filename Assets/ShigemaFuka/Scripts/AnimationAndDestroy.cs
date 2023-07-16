using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �A�j���[�V�������鎩�g��j��
/// </summary>
public class AnimationAndDestroy : MonoBehaviour
{
    [Tooltip("���ʃA�j���[�^�[")] Animator _animator = default;
    [SerializeField, Tooltip("��������(Generator���Z�����邱��)")] float _lifeTime = 5f;
    [SerializeField, Tooltip("�A�j���[�V�����̃X�e�[�g��")] string _stateName; 

    void Start()
    {
        _animator = GetComponent<Animator>(); 
        _animator.Play(_stateName);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, _lifeTime);
    }
}
