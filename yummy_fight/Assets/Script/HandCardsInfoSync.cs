using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class HandCardsInfoSync : MonoBehaviourPun
{
    private GameDirecter gameDirecter; // 変数名をリクエストに合わせて修正

    void Start()
    {
        GameObject gameDirecterObject = GameObject.Find("GameDirecter"); // GameObject.Findの引数を"GameDirecter"に変更
        if (gameDirecterObject != null)
        {
            gameDirecter = gameDirecterObject.GetComponent<GameDirecter>(); // GameObjectからGameDirecterコンポーネントを取得

            // GameDirecterコンポーネントを取得できた場合にデバッグログを出力
            if (gameDirecter != null)
            {
                Debug.Log("うおおおおおおおおおお");
            }
            else
            {
                Debug.LogError("GameDirecter component not found on the object.");
            }
        }
        else
        {
            Debug.LogError("GameDirecter object not found in the scene."); // 一貫性のためのエラーメッセージを更新
        }
    }

    public void SyncHandCardsCount()
    {
        int count = gameDirecter.playerHandCardList.Length; // GameDirecterからプレイヤー手札リストを取得
        photonView.RPC("UpdateOpponentHandCardsCount", RpcTarget.Others, count);
    }

    [PunRPC]
    void UpdateOpponentHandCardsCount(int count)
    {
        // ここで相手側のUIを更新して、相手の手札枚数を表示します。
    }
}