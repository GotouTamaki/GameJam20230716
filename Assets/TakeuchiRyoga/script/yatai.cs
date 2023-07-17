using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yatai : MonoBehaviour
{

    //  プレイヤーが当たった場合に勾玉を減らす関数の呼び出し
    private void OnTriggerEnter(Collider other)
    {
        //  プレイヤーに当たった場合、オブジェクトの削除   
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        GameManager.Instance.DropMagatama();

    }

}
