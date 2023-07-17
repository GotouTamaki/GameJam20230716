using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
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
        if (GameManager.Instance.IsGameStart == true) 
        {
            _animator.Play("Light", 0);
        }
    }
}
