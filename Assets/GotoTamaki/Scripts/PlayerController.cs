using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("�O�i�̃X�s�[�h")] float _moveForwardSpeed = 1f;
    [SerializeField, Header("�������̃X�s�[�h")] float _moveHorizontalSpeed = 1f;

    // �e�평����
    GameManager gameManager = null;
    Rigidbody _rb = null;
    AudioSource _audioSource = null;
    /// <summary>���������̓��͒l</summary>
    float _h = 0;
    /// <summary>�X�^�[�g�O�̃J�E���g�_�E���p�^�C�}�[</summary>
    float _startCount = 3f;
    /// <summary>�����p�̃t���O</summary>
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
        // ���������̓��͂��擾����
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
            //Debug.Log("�����");
            // �O�i����
            _rb.velocity = Vector3.forward * _moveForwardSpeed;
            // ���ړ�
            _rb.AddForce(Vector3.right * _h * _moveHorizontalSpeed, ForceMode.Force);           
        } 
    }

    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.tag == "Block")
        {
            //���ʂ𗎂Ƃ�����
            GameManager.Instance.DropMagatama();
        }
        else if (other.gameObject.tag == "Goal")
        {
            //�N���A����
            GameManager.Instance.Goal();
        }
    }
}
