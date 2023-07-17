using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChochinGeneretor : MonoBehaviour
{
    [SerializeField, Header("敵のオブジェクト")] GameObject _tyotin = null;
    [SerializeField, Header("最初のインターバル")] float _startInterval = 1f;
    [SerializeField, Header("提灯のボイス")] AudioClip _chochin = null;
    [SerializeField, Header("ボイスのボリューム")] float _volume = 1.0f;
    [SerializeField, Header("最小インターバル"), Range(5, 8)] float _minInterval = 1f;
    [SerializeField, Header("最大インターバル"), Range(5, 8)] float _maxInterval = 1f;
    [SerializeField, Header("インターバル"), Range(5, 8)] float _interval = 1f;   

    // 各種初期化
    GameManager gameManager = null;
    AudioSource _audioSource = null;

    /// <summary>最初の待機時間の処理</summary>
    IEnumerator Start()
    {
        gameManager = GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        //Debug.Log("start");
        enabled = false;
        yield return new WaitForSeconds(_startInterval);
        enabled = true;
        //Debug.Log("EndStart");
        StartCoroutine(TyotinGene(_interval));
    }

    /// <summary>提灯のジェネレーター</summary>
    /// <param name="interval">生成のインターバル</param>
    IEnumerator TyotinGene(float interval)
    {
        yield return new WaitForSeconds(interval);

        // 提灯の出現の可否の判定
        if (GameManager.Instance._isChouchinSpawnning == false)
        {
            //Debug.Log("提灯スポーン");
            GameObject enemy = Instantiate(_tyotin, this.transform.position, this.transform.rotation);
            _audioSource.PlayOneShot(_chochin, _volume);
            GameManager.Instance._isChouchinSpawnning = true;
        }

        // インターバルをランダムにする
        _interval = Random.Range(_minInterval, _maxInterval);
        //Debug.Log(_interval);
        StartCoroutine(TyotinGene(_interval));
    }
}
