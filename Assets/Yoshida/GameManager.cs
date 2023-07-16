using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("�N���A�ɕK�v�Ȍ��ʂ̐�")] int _clearMagatama = 3;
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

    /// <summary>���ʂ̏����������Z</summary>
    public void AddMagatama()
    {
        _nowMagatamaCount++;
    }
    /// <summary>���ʂ̏�������1�ȏ�̎��Ɍ��ʂ𗎂Ƃ�</summary>
    public void DropMagatama()
    {
        _hitCount++;
        if (_nowMagatamaCount > 0)
        {
            _nowMagatamaCount--;
        }
    }
    /// <summary>�S�[�����̃��\�b�h</summary>
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
