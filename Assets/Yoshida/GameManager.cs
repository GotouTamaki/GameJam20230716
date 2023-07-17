using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("~~クリアに必要な勾玉の数~~")] int _clearMagatama = 3;
    [SerializeField, Header("取得してない勾玉の画像")] Image[] _magatamaImage;
    [SerializeField, Header("勾玉入手後の画像")] Image _magatamaGetImage;
    [SerializeField, Header("勾玉消滅後の画像")] Image _magatamaDropImage;

    /// <summary>勾玉の取得UIを格納している配列の要素番号</summary>
    int _magatamaIndexCount = 0;
    int _magatamaDropIndexCount = 0;
    float _nowMagatamaCount;
    public float NowMagatamaCount => _nowMagatamaCount;
    int _hitCount;
    public int HitCount => _hitCount;

    bool _isGameOver = false;
    bool _isGameClear = false;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        _isGameOver = true;
        SceneManager.LoadScene("GameOver");
    }

    public void GameClear()
    {
        _isGameClear = true;
        PlayerPrefs.SetInt("HitCount", HitCount);
        SceneManager.LoadScene("GameClear");
    }

    /// <summary>勾玉の所持数を加算</summary>
    public void AddMagatama()
    {
        if (_magatamaIndexCount < _magatamaImage.Length)
        {
            _magatamaImage[_magatamaIndexCount].sprite = _magatamaGetImage.sprite;
        }
        _nowMagatamaCount++;
        _magatamaIndexCount++;
        print(_nowMagatamaCount);
    }
    /// <summary>勾玉の所持数が1つ以上の時に勾玉を落とす</summary>
    public void DropMagatama()
    {
        _hitCount++;
        if (_nowMagatamaCount > 0)
        {
            _nowMagatamaCount--;
            _magatamaIndexCount--;
            _magatamaImage[_magatamaIndexCount].sprite = _magatamaDropImage.sprite;
        }
        print(_nowMagatamaCount);
    }
    /// <summary>ゴール時のメソッド</summary>
    public void Goal()
    {
        if (_nowMagatamaCount < _clearMagatama)
        {
            GameOver();
        }
        else
        {
            GameClear();
        }
    }
}
