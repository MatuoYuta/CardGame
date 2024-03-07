using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class HandCardsInfoSync : MonoBehaviourPun
{
    // �ϐ��������N�G�X�g�ɍ��킹�ďC��
    private GameDirecter gameDirecter; // �X�y���̏C��

    void Start()
    {
        // GameObject�̕ϐ����ƃR�����g����ѐ��̂��߂ɏC��
        GameObject gameDirecterObject = GameObject.Find("GameDirecterObject"); // �X�y�����C��
        if (gameDirecterObject != null)
        {
            // GameObject����GameDirecter�R���|�[�l���g���擾
            gameDirecter = gameDirecterObject.GetComponent<GameDirecter>(); // �X�y���ƕϐ������C��
        }
        else
        {
            Debug.LogError("GameDirecter object not found in the scene."); // ��ѐ��̂��߂̃G���[���b�Z�[�W���X�V
        }
    }

    // ��D�����𓯊����邽�߂̃��\�b�h
    public void SyncHandCardsCount()
    {
        // GameDirecter����v���C���[��D���X�g���擾
        int count = gameDirecter.playerHandCardList.Length; // �������ϐ������g�p���ďC��
        photonView.RPC("UpdateOpponentHandCardsCount", RpcTarget.Others, count);
    }

    [PunRPC]
    void UpdateOpponentHandCardsCount(int count)
    {
        // �����ő��葤��UI���X�V���āA����̎�D������\�����܂��B
    }
}