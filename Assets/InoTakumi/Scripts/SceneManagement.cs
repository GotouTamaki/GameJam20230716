using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    
    
    void MoveToPlayScene()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }


    void MoveToTitleScene()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }


    bool ClearFlag()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return true;
        }
        return false;
    }


    bool DeadFlag()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        MoveToPlayScene();

        if(SceneManager.GetActiveScene().name == "PlayScene")
        {
            // クリア後、タイトルシーンに遷移
            if ( ClearFlag())   SceneManager.LoadScene("TitleScene");
            // 死亡後、プレイシーンをリロード
            if ( DeadFlag()) SceneManager.LoadScene("PlayScene");
        }

        
    }
}
