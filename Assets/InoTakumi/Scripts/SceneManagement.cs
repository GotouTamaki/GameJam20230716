using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    bool isClear = false, isDead = false;   
    
    void MoveToPlayScene()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }



    void ClearFlagOn()
    {
       if(Input.GetKeyDown(KeyCode.Alpha1)) isClear = true;
    }


    void DeadFlagOn()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) isDead = true;
    }

    private void Update()
    {
        MoveToPlayScene();
        ClearFlagOn();
        DeadFlagOn();

        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            // �N���A��A�^�C�g���V�[���ɑJ��
            if (isClear)
            {
                SceneManager.LoadScene("TitleScene");
                isClear = false;
            }
            // ���S��A�v���C�V�[���������[�h
            if (isDead)
            {
                SceneManager.LoadScene("PlayScene");
                isDead = false;
            }
        }        
    }
}
