using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject clearCanvas;
    public GameObject DeadCanvas;



    bool isClear = false, isDead = false;

    float mtCount = 0;

    private void Awake()
    {
       
    }

    void MoveToPlayScene()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }        
    }



    
    private void Update()
    {
        MoveToPlayScene();


        if (mtCount >= 10)
        {
            isClear = true;
        }
        else
        {
            isDead = true;
        }

        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            // クリア後、タイトルシーンに遷移
            if (isClear)
            {
                clearCanvas.SetActive(true);

                if(Input.GetKeyDown (KeyCode.Return))
                {
                    clearCanvas.SetActive(false);
                    isClear = false;
                    SceneManager.LoadScene("TitleScene");                    
                }
               
            }

            // 死亡後、プレイシーンをリロード
            if (isDead)
            {
                DeadCanvas.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    DeadCanvas.SetActive(false);
                    isDead = false;
                    SceneManager.LoadScene("PlayScene");                    
                }
            }
        }        
    }
}
