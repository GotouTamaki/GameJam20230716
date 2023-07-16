using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("クリアに必要な勾玉の数")] int _clearMagatama = 3;
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
        _nowMagatamaCount++;
    }
    /// <summary>勾玉の所持数が1つ以上の時に勾玉を落とす</summary>
    public void DropMagatama()
    {
        _hitCount++;
        if (_nowMagatamaCount > 0)
        {
            _nowMagatamaCount--;
        }
    }
    /// <summary>ゴール時のメソッド</summary>
    public void Goal()
    {
        if (NowMagatamaCount < 3)
        {
            GameOver();
        }
        else
        {
            GameClear();
        }
    }
}
