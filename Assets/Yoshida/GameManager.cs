using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("~~�N���A�ɕK�v�Ȍ��ʂ̐�~~")] int _clearMagatama = 3;
    [SerializeField, Header("�擾���ĂȂ����ʂ̉摜")] Image[] _magatamaImage;
    [SerializeField, Header("���ʓ����̉摜")] Image _magatamaGetImage;
    [SerializeField, Header("���ʏ��Ō�̉摜")] Image _magatamaDropImage;

    /// <summary>���ʂ̎擾UI���i�[���Ă���z��̗v�f�ԍ�</summary>
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

    /// <summary>���ʂ̏����������Z</summary>
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
    /// <summary>���ʂ̏�������1�ȏ�̎��Ɍ��ʂ𗎂Ƃ�</summary>
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
    /// <summary>�S�[�����̃��\�b�h</summary>
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
