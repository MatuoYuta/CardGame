using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class AttackButton : MonoBehaviour
{
    // �U���Ώ�
    public GameObject target;
    // �v���C���[�̃X�e�[�^�X
    public PlayerStats playerStats;
    // �����X�^�[�̃X�e�[�^�X
    public MonsterStats monsterStats; 

    // �U���{�^���������ꂽ�Ƃ��ɌĂяo�����֐�
    public void OnAttackButtonClicked()
    {
        if (target != null)
        {
            // �U���Ώۂ��v���C���[�������X�^�[���ŏ����𕪊�
            if (target.CompareTag("Player"))
            {
                // �v���C���[�̏ꍇ�A���C�t��1���
                if (playerStats != null)
                {
                    playerStats.TakeDamage(1);
                }
                else
                {
                    Debug.LogError("PlayerStats��������܂���ł����B");
                }
            }
            else if (target.CompareTag("Monster"))
            {
                // �����X�^�[�̏ꍇ�A�U���͂��r���ă_���[�W�������s��
                if (playerStats != null && monsterStats != null)
                {
                    if (playerStats.attackPower >= monsterStats.attackPower)
                    {
                        monsterStats.TakeDamage(playerStats.attackPower);
                    }
                    else
                    {
                        playerStats.TakeDamage(monsterStats.attackPower);
                    }
                }
                else
                {
                    Debug.LogError("PlayerStats�܂���MonsterStats��������܂���ł����B");
                }
            }
            else
            {
                Debug.LogError("�U���Ώۂ��s���ł��B");
            }
        }
        else
        {
            Debug.LogError("�U���Ώۂ��ݒ肳��Ă��܂���B");
        }
    }
}*/