using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class HandCardsInfoSync : MonoBehaviourPun
{
    // 変数名をリクエストに合わせて修正
    private GameDirecter gameDirecter; // スペルの修正

    void Start()
    {
        // GameObjectの変数名とコメントを一貫性のために修正
        GameObject gameDirecterObject = GameObject.Find("GameDirecterObject"); // スペルを修正
        if (gameDirecterObject != null)
        {
            // GameObjectからGameDirecterコンポーネントを取得
            gameDirecter = gameDirecterObject.GetComponent<GameDirecter>(); // スペルと変数名を修正
        }
        else
        {
            Debug.LogError("GameDirecter object not found in the scene."); // 一貫性のためのエラーメッセージを更新
        }
    }

    // 手札枚数を同期するためのメソッド
    public void SyncHandCardsCount()
    {
        // GameDirecterからプレイヤー手札リストを取得
        int count = gameDirecter.playerHandCardList.Length; // 正しい変数名を使用して修正
        photonView.RPC("UpdateOpponentHandCardsCount", RpcTarget.Others, count);
    }

    [PunRPC]
    void UpdateOpponentHandCardsCount(int count)
    {
        // ここで相手側のUIを更新して、相手の手札枚数を表示します。
    }
}