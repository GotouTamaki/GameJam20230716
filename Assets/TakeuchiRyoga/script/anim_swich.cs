using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_swich : MonoBehaviour
{

    [SerializeField]Animator yatai_anim;
    [SerializeField] string anim_name;
    
    //  プレイヤーがスイッチに接触した場合、屋台のアニメーションを実行
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            yatai_anim.Play(anim_name);
        }

    }
}
