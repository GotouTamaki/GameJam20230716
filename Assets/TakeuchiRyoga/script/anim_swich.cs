using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_swich : MonoBehaviour
{

    [SerializeField]Animator yatai_anim;
    [SerializeField] string anim_name;
    
    //  �v���C���[���X�C�b�`�ɐڐG�����ꍇ�A����̃A�j���[�V���������s
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            yatai_anim.Play(anim_name);
        }

    }
}
