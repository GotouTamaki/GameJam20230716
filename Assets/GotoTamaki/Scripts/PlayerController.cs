using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("�O�i�̃X�s�[�h")] float _moveForwardSpeed = 1f;
    [SerializeField, Header("�������̃X�s�[�h")] float _moveHorizontalSpeed = 1f;

    // �e�평����
    Rigidbody _rb = null;
    // ���������̓��͒l
    float _h;
    // �X�^�[�g�O�̃J�E���g�_�E���p�^�C�}�[
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

        // ���������̓��͂��擾����
        _h = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_startTimar < 0) 
        {
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
            //animation
            //audio
        }
        else if (other.gameObject.tag == "Goal")
        {
            //�N���A����
        }
    }
}
