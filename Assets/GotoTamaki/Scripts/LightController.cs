using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // 各種初期化
    Animator _animator = null;
    GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームスタート時にアニメーションスタート
        if (GameManager.Instance.IsGameStart == true) 
        {
            _animator.Play("Light", 0);
        }
    }
}
