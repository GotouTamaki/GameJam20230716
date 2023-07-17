using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // �e�평����
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
        // �Q�[���X�^�[�g���ɃA�j���[�V�����X�^�[�g
        if (GameManager.Instance.IsGameStart == true) 
        {
            _animator.Play("Light", 0);
        }
    }
}
