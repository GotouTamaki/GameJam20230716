using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDpwnController : MonoBehaviour
{
    AudioSource _audioSource = null;
    Animator _animator = null;
    /// <summary>‘«‰¹—p‚Ìƒtƒ‰ƒO</summary>
    bool _animPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameStart == true && _animPlay == false)
        {
            Destroy(gameObject, 3f);
            _animator.Play("StartCount", 0);
            _animPlay = true;
        }
    }

    public void CountAudio()
    {
        _audioSource.Play();
    }
}
