using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTossGame : MonoBehaviour
{
    void Start()
    {
        // 先攻後攻を決める
        string playerTurn = ChooseTurn();

        // ゲームを始める
        StartGame(playerTurn);
    }

    string CoinToss()
    {
        // コイントスで表か裏をランダムに選ぶ
        string result = (Random.Range(0, 2) == 0) ? "表" : "裏";
        return result;
    }

    string ChooseTurn()
    {
        // コイントスの結果を取得
        string coinResult = CoinToss();

        Debug.Log("コイントスの結果: " + coinResult);

        // 表が出たら先攻、裏が出たら後攻を選ぶ
        if (coinResult == "表")
        {
            Debug.Log("先攻を選びます！");
            return "先攻";
        }
        else
        {
            Debug.Log("裏が出たので、相手が先攻を選びます。");
            return "後攻";
        }
    }

    void StartGame(string turn)
    {
        Debug.Log(turn + "の番です。ゲームが始まります！");
        // ここにゲームの開始に関するコードを追加
    }
}
