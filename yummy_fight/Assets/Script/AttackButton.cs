using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public GameObject cardObject; // �������ɂ���Card�I�u�W�F�N�g
    private Button attackButton; // �{�^���̎Q��

    void Start()
    {
        // �{�^���R���|�[�l���g���擾
        attackButton = GetComponent<Button>();
    }

    public void OnAttackButtonClick()
    {
        Debug.Log("����ɍU������");
        RotateCard(); // �J�[�h���������ɂ��郁�\�b�h���Ăяo��
        AttackPlayer(); // �v���C���[�ɍU�����郁�\�b�h���Ăяo��
        // �{�^�����\���ɂ���
        gameObject.SetActive(false);
    }

    void RotateCard()
    {
        // �J�[�h��90�x��]������
        cardObject.transform.Rotate(new Vector3(0f, 0f, 90f));
    }

    void AttackPlayer()
    {
        // �v���C���[�I�u�W�F�N�g���^�O�Ō������Ď擾
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // �v���C���[�I�u�W�F�N�g�����݂���ꍇ
        if (player != null)
        {
            // �v���C���[�I�u�W�F�N�g�Ƀ_���[�W��^����Ȃǂ̏����������ɋL�q
            // �ȉ��̓_���[�W��^���鏈���̗�
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // ��Ƃ���10�̃_���[�W��^����
            }
        }
        else
        {
            Debug.LogWarning("�v���C���[�I�u�W�F�N�g��������܂���ł����I");
        }
    }
}
