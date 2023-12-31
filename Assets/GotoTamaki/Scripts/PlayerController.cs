using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("前進のスピード")] float _moveForwardSpeed = 1f;
    [SerializeField, Header("横方向のスピード")] float _moveHorizontalSpeed = 1f;

    // 各種初期化
    GameManager gameManager = null;
    Rigidbody _rb = null;
    AudioSource _audioSource = null;
    /// <summary>水平方向の入力値</summary>
    float _h = 0;
    /// <summary>スタート前のカウントダウン用タイマー</summary>
    float _startCount = 3f;
    /// <summary>足音用のフラグ</summary>
    bool _footstepsPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        gameManager = GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 垂直方向の入力を取得する
        _h = Input.GetAxisRaw("Horizontal");
        //if (_h >= 0) 
        //{
        //    Debug.Log(_h);
        //}

        if (GameManager.Instance.IsGameStart == true)
        {
            _startCount -= Time.deltaTime;
        }

        if (GameManager.Instance.IsGameStart == true && _footstepsPlay == false && _startCount < 0)
        {
            _audioSource.Play();
            _footstepsPlay = true;         
        }
    }

    private void FixedUpdate()
    {
        if (_startCount < 0 && GameManager.Instance.IsGameStart == true) 
        {
            //Debug.Log("操作可");
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
            GameManager.Instance.DropMagatama();
        }
        else if (other.gameObject.tag == "Goal")
        {
            //クリア判定
            GameManager.Instance.Goal();
        }
    }
}
