using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// お面の表示
/// 開始数秒はギミックが生成されない
/// 数秒経過後は、変動するインターバルおきに生成される
/// 
/// </summary>
public class OmenActive : MonoBehaviour
{
    [SerializeField, Tooltip("使用開始時間")] float _startTime = 30f; 
    [SerializeField, Tooltip("お面のオブジェクト")] GameObject _omen = default;
    [Tooltip("経過時間")] float _time = 0;
    [SerializeField, Tooltip("変動する生成インターバル")] float _interval = 0;
    [SerializeField, Tooltip("消えてからの再生成までの最小値")] int _min = 0;
    [SerializeField, Tooltip("消えてからの再生成までの最大値")] int _max = 0;
    [SerializeField, Tooltip("アニメーションの生存時間")] float _lifeTime = 5f;
    [Tooltip("アニメーションを表示するための時間経過")] float _animTime = 0;
    [SerializeField] float _timeCount = 0;
    [SerializeField, Tooltip("再使用防止")] bool canUseGimmick = default;
    [SerializeField] AudioSource _audioSource = default; 
    void Update()
    {
        _timeCount += Time.deltaTime;
        _time += Time.deltaTime;

        // ゲーム開始から「_startTime」秒間はギミックを生成不可にする 
        if (_time > _startTime && !canUseGimmick)
        {
            canUseGimmick = true;
            _time = 0;
        }
        if (canUseGimmick)
        {
            // インターバルが経過したら生成  ※提灯との同時生成防止のためのフラグ（調整できてない）
            if (_time > _interval && GameManager.Instance._isOmenSpawnnig == false)
            {
                _omen.SetActive(true); 
                _audioSource.Play(); 
                GameManager.Instance._isOmenSpawnnig = true;
            }
            // 生成してからカウントダウン
            if (GameManager.Instance._isOmenSpawnnig == true)
            {
                _animTime += Time.deltaTime;
            }
            // 「_lifeTime」秒経過したらアニメーションをオブジェクトを非アクティブ  
            if (_animTime > _lifeTime)
            {
                Debug.Log(_animTime);
                _animTime = 0;
                _time = 0;
                _omen.SetActive(false);
                GameManager.Instance._isOmenSpawnnig = false;
                // 生成のインターバルを「_min～_max」の間でランダムに設定する 
                _interval = Random.Range(_min, _max + 1);
            }
        }
    }
}