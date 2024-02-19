using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTossGame : MonoBehaviour
{
    void Start()
    {
        // ��U��U�����߂�
        string playerTurn = ChooseTurn();

        // �Q�[�����n�߂�
        StartGame(playerTurn);
    }

    string CoinToss()
    {
        // �R�C���g�X�ŕ\�����������_���ɑI��
        string result = (Random.Range(0, 2) == 0) ? "�\" : "��";
        return result;
    }

    string ChooseTurn()
    {
        // �R�C���g�X�̌��ʂ��擾
        string coinResult = CoinToss();

        Debug.Log("�R�C���g�X�̌���: " + coinResult);

        // �\���o�����U�A�����o�����U��I��
        if (coinResult == "�\")
        {
            Debug.Log("��U��I�т܂��I");
            return "��U";
        }
        else
        {
            Debug.Log("�����o���̂ŁA���肪��U��I�т܂��B");
            return "��U";
        }
    }

    void StartGame(string turn)
    {
        Debug.Log(turn + "�̔Ԃł��B�Q�[�����n�܂�܂��I");
        // �����ɃQ�[���̊J�n�Ɋւ���R�[�h��ǉ�
    }
}
