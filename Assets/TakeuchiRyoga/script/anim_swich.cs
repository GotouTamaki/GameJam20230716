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

    //  �v���C���[���X�C�b�`�ɐڐG�����ꍇ�A����̃A�j���[�V���������s
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
