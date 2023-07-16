using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("前進のスピード")] float _moveForwardSpeed = 1f;
    [SerializeField, Header("横方向のスピード")] float _moveHorizontalSpeed = 1f;

    // 各種初期化
    Rigidbody _rb = null;
    // 水平方向の入力値
    float _h;
    // スタート前のカウントダウン用タイマー
    float _startTimar = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _startTimar -= Time.deltaTime;

        // 垂直方向の入力を取得する
        _h = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_startTimar < 0) 
        {
            // 前進する
            _rb.velocity = Vector3.forward * _moveForwardSpeed;
            // 横移動
            _rb.AddForce(Vector3.right * _h * _moveHorizontalSpeed, ForceMode.Force);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.tag == "Block")
        {
            //勾玉を落とす処理
            //animation
            //audio
        }
        else if (other.gameObject.tag == "Goal")
        {
            //クリア判定
        }
    }
}
