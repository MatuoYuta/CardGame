using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameDirecter : MonoBehaviour
{

    public Player1[] playerList;//プレイヤーのリスト
    public bool Movable;//動けるか(スタンバイフェーズ)
    public bool Summonable;//召喚できるか(メインフェーズ)
    public bool Attackable;//攻撃できるか（バトルフェーズ）
    public GameObject phase_text;//どのフェーズかを表示する

    public GameManager manage_script;
    public CPU cpu_script;
    public GameObject before_outline;
    public GameObject before_outline_object;

    public CardController[] playerHandCardList;//プレイヤーの手札を格納するリスト
    public CardController[] playerFieldCardList;//フィールドのカードを格納するリスト
    public CardController[] playerkitchenCardList;//調理場のカードを格納するリスト
    public CardController[] enemyHandCardList;//敵の手札を格納するリスト
    public CardController[] EnemyKitchenCardList;//敵の調理場のカードを格納するリスト
    public CardController[] EnemyFieldCardList;//敵のフィールドのカードを格納するリスト

    public ObjectHighlight[] SearchImageList;//サーチするカード

    public int turn;
    public bool main, battle;

    public enum Phase//フェーズ管理用列挙型変数
    {
        INIT,
        DRAW,
        STANDBY,
        MAIN,
        BATTLE,
        END,
        Enemy_INIT,
        Enemy_DRAW,
        Enemy_STANDBY,
        Enemy_MAIN,
        Enemy_BATTLE,
        Enemy_END,
    };

    Phase phase;
    Player1 currentPlayer;
    void Start()
    {
        phase = Phase.INIT;
        Movable = false;
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        cpu_script = this.gameObject.GetComponent<CPU>();
        main = true;
        battle = true;
    }
    void Update()
    {
        //カードのリスト格納
        playerHandCardList = manage_script.playerHand.GetComponentsInChildren<CardController>();
        playerFieldCardList = manage_script.playerField.GetComponentsInChildren<CardController>();
        playerkitchenCardList = manage_script.playerKitchen.GetComponentsInChildren<CardController>();

        enemyHandCardList = manage_script.enemyHand.GetComponentsInChildren<CardController>();
        EnemyFieldCardList = manage_script.enemyField.GetComponentsInChildren<CardController>();
        EnemyKitchenCardList = manage_script.enemyKitchen.GetComponentsInChildren<CardController>();

        SearchImageList = manage_script.searchArea.GetComponentsInChildren<ObjectHighlight>();


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
            case Phase.Enemy_DRAW://ドローフェーズ
                turn++;
                Enemy_DrawPhase();
                break;
            case Phase.Enemy_STANDBY://スタンバイ（移動）フェーズ
                Enemy_StandbyPhase();
                break;
            case Phase.Enemy_MAIN://メインフェーズ
                Enemy_MainPhase();
                break;
            case Phase.Enemy_BATTLE://バトルフェーズ
                Enemy_BattlePhase();
                break;
            case Phase.Enemy_END://エンドフェーズ
                Enemy_EndPhase();
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

        // StandbyPhaseに入ったときにカードの向きをリセット
        ResetCardRotation(playerFieldCardList);
    }

    // Player_fieldにあるカードの向きをリセットする関数
    void ResetCardRotation(CardController[] cards)
    {
        foreach (var card in cards)
        {
            if (card != null)
            {
                card.transform.rotation = Quaternion.identity;
            }
        }
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

        // BATTLEフェーズに入ったのでクリックを許可する
        foreach (var objClickExample in FindObjectsOfType<ObjectClickExample>())
        {
            objClickExample.EnterBattlePhase();
        }
    }
    void EndPhase()
    {
        Debug.Log("EndPhase");
        Attackable = false;
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nEnd";
        //if (currentPlayer == playerList[0])
        //{
        //    currentPlayer = playerList[1];
        //}
        //else
        //{
        //    currentPlayer = playerList[0];
        //}
        phase = Phase.Enemy_DRAW;

        // BATTLEフェーズから出たのでクリックを禁止する
        foreach (var objClickExample in FindObjectsOfType<ObjectClickExample>())
        {
            objClickExample.ExitBattlePhase();
        }
    }

    void Enemy_DrawPhase()
    {
        Debug.Log("Enemy_DrawPhase");
        phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nDraw";
        currentPlayer.EnemyDraw();
        phase = Phase.Enemy_STANDBY;
    }

    void Enemy_StandbyPhase()
    {
        Debug.Log("Enemy_StandbyPhase");
        phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nStandby";
        phase = Phase.Enemy_MAIN;
    }

    void Enemy_MainPhase()
    {
        if(main)
        {
            Debug.Log("Enemy_MainPhase");
            phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nMain";
            cpu_script.Main(turn);
            main = false;
        }
        //phase = Phase.Enemy_BATTLE;
    }

    void Enemy_BattlePhase()
    {
        if(battle)
        {
            Debug.Log("Enemy_BattlePhase");
            phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nBattle";
            main = true;
            battle = false;
        }
    }

    void Enemy_EndPhase()
    {
        Debug.Log("Enemy_EndPhase");
        phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nEnd";
        phase = Phase.DRAW;
        battle = true;
    }

    public void Change_Main()
    {
        phase = Phase.Enemy_MAIN;
    }

    public void Change_Battle()
    {
        phase = Phase.Enemy_BATTLE;
    }

    public void Change_End()
    {
        phase = Phase.Enemy_END;
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
