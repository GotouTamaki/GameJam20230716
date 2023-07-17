using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChochinController : MonoBehaviour
{
    [SerializeField, Header("当たった音")] AudioClip _hit = null;
    [SerializeField, Header("提灯のボイス")] AudioClip _chochin = null;
    [SerializeField, Header("当たった音ボリューム")] float __hitvolume = 1.0f;
    [SerializeField, Header("ボイスのボリューム")] float __chochinVolume = 1.0f;

    AudioSource _audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        //anim
        _audioSource = GetComponent<AudioSource>();
        // 5秒後に呼び出す
        Invoke(nameof(ChochinDestroy), 5f);
    }

    void ChochinDestroy()
    {
        GameManager.Instance._isChouchinSpawnning = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.PlayOneShot(_hit, __hitvolume);
        _audioSource.PlayOneShot(_chochin, __chochinVolume);
    }
}
