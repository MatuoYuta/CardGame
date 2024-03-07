using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public GameObject cardObject; // �������ɂ���Card�I�u�W�F�N�g

    public void OnAttackButtonClick()
    {
        Debug.Log("����ɍU������");
        RotateCard(); // �J�[�h���������ɂ��郁�\�b�h���Ăяo��
    }

    void RotateCard()
    {
        // �J�[�h��90�x��]������
        cardObject.transform.Rotate(new Vector3(0f, 0f, 90f));
    }
}