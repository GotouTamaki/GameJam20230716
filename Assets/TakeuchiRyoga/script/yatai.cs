using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yatai : MonoBehaviour
{

    //  �v���C���[�����������ꍇ�Ɍ��ʂ����炷�֐��̌Ăяo��
    private void OnTriggerEnter(Collider other)
    {
        //  �v���C���[�ɓ��������ꍇ�A�I�u�W�F�N�g�̍폜   
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        GameManager.Instance.DropMagatama();

    }

}
