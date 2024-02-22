using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Synchronization : MonoBehaviour
{
    private PhotonView photonView;

    private void SummonCard(CardModel CardModel)
    {
        // カードデータを相手に送信
        photonView.RPC("ReceiveCardData", RpcTarget.Others, CardModel);
    }

    // ネットワーク越しに呼び出されるメソッド
    [PunRPC]
    private void ReceiveCardData(CardModel CardModel)
    {
        // 受け取ったカードデータを利用してカード生成などの処理を行う
        SpawnCard(CardModel);
    }

    // カード生成メソッド
    private void SpawnCard(CardModel CardModel)
    {
        // カード生成などの処理をここに追加
    }
}