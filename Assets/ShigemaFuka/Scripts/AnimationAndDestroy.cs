using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アニメーションする自身を破棄
/// </summary>
public class AnimationAndDestroy : MonoBehaviour
{
    [Tooltip("お面アニメーター")] Animator _animator = default;
    [SerializeField, Tooltip("生存時間(Generatorより短くすること)")] float _lifeTime = 5f;
    [SerializeField, Tooltip("アニメーションのステート名")] string _stateName; 

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
