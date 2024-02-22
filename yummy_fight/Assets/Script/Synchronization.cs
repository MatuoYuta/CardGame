using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Synchronization : MonoBehaviour
{
    private PhotonView photonView;

    private void SummonCard(CardModel CardModel)
    {
        // �J�[�h�f�[�^�𑊎�ɑ��M
        photonView.RPC("ReceiveCardData", RpcTarget.Others, CardModel);
    }

    // �l�b�g���[�N�z���ɌĂяo����郁�\�b�h
    [PunRPC]
    private void ReceiveCardData(CardModel CardModel)
    {
        // �󂯎�����J�[�h�f�[�^�𗘗p���ăJ�[�h�����Ȃǂ̏������s��
        SpawnCard(CardModel);
    }

    // �J�[�h�������\�b�h
    private void SpawnCard(CardModel CardModel)
    {
        // �J�[�h�����Ȃǂ̏����������ɒǉ�
    }
}