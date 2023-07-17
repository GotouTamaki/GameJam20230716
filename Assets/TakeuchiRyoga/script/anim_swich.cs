using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_swich : MonoBehaviour
{

    private Animator yatai_anim;

    // Start is called before the first frame update
    void Start()
    {
        yatai_anim = GetComponent<Animator>();
    }

    //  プレイヤーがスイッチに接触した場合、屋台のアニメーションを実行
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "")
        {
            yatai_anim.SetBool("Bool", true);
        }
        else
        {
            yatai_anim.SetBool("Bool", false);
        }
    }
}
