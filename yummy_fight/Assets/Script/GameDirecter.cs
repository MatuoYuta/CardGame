using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirecter : MonoBehaviour
{

    public Player1[] playerList;//プレイヤーのリスト
    public bool Movable;//動けるか(スタンバイフェーズ)
    public bool Summonable;//召喚できるか(メインフェーズ)
    public bool Attackable;//攻撃できるか（バトルフェーズ）
    public GameObject phase_text;//どのフェーズかを表示する

    public GameManager manage_script;

    public CardController[] playerFieldCardList;//フィールドのカードを格納するリスト
    public CardController[] playerkitchenCardList;//調理場のカードを格納するリスト

    public enum Phase//フェーズ管理用列挙型変数
    {
        INIT,
        DRAW,
        STANDBY,
        MAIN,
        BATTLE,
        END,
    };

    Phase phase;
    Player1 currentPlayer;
    void Start()
    {
        phase = Phase.INIT;
        Movable = false;
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        //カードのリスト格納
        playerFieldCardList = manage_script.playerField.GetComponentsInChildren<CardController>();
        playerkitchenCardList = manage_script.playerKitchen.GetComponentsInChildren<CardController>();

        switch (phase)
        {
            case Phase.INIT://初期フェーズ
                currentPlayer = playerList[0];
                InitPhase();
                break;
            case Phase.DRAW://ドローフェーズ
                DrawPhase();
                break;
            case Phase.STANDBY://スタンバイ（移動）フェーズ
                StandbyPhase();
                break;
            case Phase.MAIN://スタンバイ（移動）フェーズ
                MainPhase();
                break;

            case Phase.BATTLE://バトルフェーズ
                BattlePhase();
                break;
            case Phase.END://エンドフェーズ
                EndPhase();
                break;
        }
    }
    void InitPhase()
    {
        Debug.Log("InitPhase");
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer+"\nInit";
        phase = Phase.DRAW;
    }
    void DrawPhase()
    {
        Debug.Log("DrawPhase");
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nDraw";
        currentPlayer.Draw();
        phase = Phase.STANDBY;
    }
    void StandbyPhase()
    {
        Debug.Log("StandbyPhase");
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nStandby";
        Movable = true;
    }

    void MainPhase()
    {
        Debug.Log("MainPhase");
        Summonable = true;
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nMain";
    }
    void BattlePhase()
    {
        Debug.Log("BattlePhase");
        Movable = false;
        Summonable = false;
        Attackable = true;
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nBattle";
    }
    void EndPhase()
    {
        Debug.Log("EndPhase");
        Attackable = false;
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nEnd";
        if (currentPlayer == playerList[0])
        {
            currentPlayer = playerList[1];
        }
        else
        {
            currentPlayer = playerList[0];
        }
        phase = Phase.DRAW;
    }
    public void NextPhase()
    {
        switch (phase)
        {
            case Phase.STANDBY://スタンバイ（移動）フェーズ
                phase = Phase.MAIN;
                break;
            case Phase.MAIN://メインフェーズ
                phase = Phase.BATTLE;
                break;
            case Phase.BATTLE://バトルフェーズ
                phase = Phase.END;
                break;
        }
    }
}
