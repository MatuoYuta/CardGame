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
    public bool Zekkouhyoujun;//箸休めが発動できるか
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

    public GameObject p_text, e_text,life_de_ukeru;
    public int turn;
    public bool main, battle;
    public int player_life, enemy_life;//プレイヤーとエネミーのライフ
    public bool enemyattack,playerattack;

    public TextMeshProUGUI phaseText;// UIテキストをアサインするためのパブリック変数

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

    public Phase phase;
    Player1 currentPlayer;
    void Start()
    {
        phase = Phase.INIT;
        life_de_ukeru.SetActive(false);
        Movable = false;
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        cpu_script = this.gameObject.GetComponent<CPU>();
        main = true;
        battle = true;
        player_life = 5;
        enemy_life = 3;
    }
    void Update()
    {
        p_text.GetComponent<TextMeshProUGUI>().text = player_life.ToString();
        e_text.GetComponent<TextMeshProUGUI>().text = enemy_life.ToString();

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
        // フェーズ変更に伴うテキストの更新
        UpdatePhaseText();
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer+"\nInit";
        phase = Phase.DRAW;
    }
    void DrawPhase()
    {
        Debug.Log("DrawPhase");
        // フェーズ変更に伴うテキストの更新
        UpdatePhaseText();
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nDraw";
        currentPlayer.Draw();
        for(int i =0;i<playerFieldCardList.Length;i++)
        {
            playerFieldCardList[i].kaihuku();
        }
        phase = Phase.STANDBY;
        manage_script.Buns = false;
        manage_script.Patty = false;
        manage_script.Muffin = false;
        manage_script.Pickles = false;
        manage_script.Foodraw = false;
        manage_script.Plan = false;
        manage_script.Stop = false;
    }
    void StandbyPhase()
    {
        Debug.Log("StandbyPhase");
        // フェーズ変更に伴うテキストの更新
        UpdatePhaseText();
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
        // フェーズ変更に伴うテキストの更新
        UpdatePhaseText();
        Summonable = true;
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nMain";
    }
    void BattlePhase()
    {
        Debug.Log("BattlePhase");
        // フェーズ変更に伴うテキストの更新
        UpdatePhaseText();
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
        // フェーズ変更に伴うテキストの更新
        UpdatePhaseText();
        Attackable = false;
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nEnd";
        for (int i = 0; i < playerFieldCardList.Length; i++)
        {
            playerFieldCardList[i].power_back();
        }
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
        // フェーズ変更に伴うテキストの更新
        UpdatePhaseText();
        phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nDraw";
        currentPlayer.EnemyDraw();
        phase = Phase.Enemy_STANDBY;
    }

    void Enemy_StandbyPhase()
    {
        Debug.Log("Enemy_StandbyPhase");
        // フェーズ変更に伴うテキストの更新
        UpdatePhaseText();
        phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nStandby";
        phase = Phase.Enemy_MAIN;
    }

    void Enemy_MainPhase()
    {
        if(main)
        {
            Debug.Log("Enemy_MainPhase");
            // フェーズ変更に伴うテキストの更新
            UpdatePhaseText();
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
            // フェーズ変更に伴うテキストの更新
            UpdatePhaseText();
            phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nBattle";
            main = true;
            battle = false;
            cpu_script.battle(turn);
        }

        if (manage_script.Stop)
        {
            phase = Phase.Enemy_END;
        }
    }

    void Enemy_EndPhase()
    {
        Debug.Log("Enemy_EndPhase");
        // フェーズ変更に伴うテキストの更新
        UpdatePhaseText();
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

    void UpdatePhaseText()
    {
        Color enemyPhaseColor = Color.red;
        switch (phase)
        {
            // プレイヤーフェーズの場合（敵フェーズでないため、デフォルトの色を使用）
            case Phase.DRAW:
                phaseText.text = "Draw Phase";
                phaseText.color = Color.white; // デフォルトの色（またはプレイヤーのフェーズ色）
                break;
            case Phase.STANDBY:
                phaseText.text = "Standby Phase";
                phaseText.color = Color.white; // デフォルトの色
                break;
            case Phase.MAIN:
                phaseText.text = "Main Phase";
                phaseText.color = Color.white; // デフォルトの色
                break;
            case Phase.BATTLE:
                phaseText.text = "Battle Phase";
                phaseText.color = Color.white; // デフォルトの色
                break;
            case Phase.END:
                phaseText.text = "End Phase";
                phaseText.color = Color.white; // デフォルトの色
                break;

            // 敵のフェーズの場合、テキストの色を赤色に設定
            case Phase.Enemy_DRAW:
                phaseText.text = "Enemy Draw Phase";
                phaseText.color = enemyPhaseColor;
                break;
            case Phase.Enemy_STANDBY:
                phaseText.text = "Enemy Standby Phase";
                phaseText.color = enemyPhaseColor;
                break;
            case Phase.Enemy_MAIN:
                phaseText.text = "Enemy Main Phase";
                phaseText.color = enemyPhaseColor;
                break;
            case Phase.Enemy_BATTLE:
                phaseText.text = "Enemy Battle Phase";
                phaseText.color = enemyPhaseColor;
                break;
            case Phase.Enemy_END:
                phaseText.text = "Enemy End Phase";
                phaseText.color = enemyPhaseColor;
                break;
            default:
                phaseText.text = "Undefined Phase";
                phaseText.color = Color.white; // デフォルトの色
                break;
        }
    }

    IEnumerator Destroy_me(GameObject me)
    {
        yield return new WaitForSeconds(1);
        Destroy(me);
    }

    public void Battle(GameObject attack,GameObject block)
    {
        int attack_power = attack.GetComponent<CardView>().power;
        int block_power = block.GetComponent<CardView>().power;
        Debug.Log("バトル開始");
        Debug.Log("アタックパワー" + attack_power);
        Debug.Log("ブロックパワー" + block_power);
        if (attack_power > block_power)
        {
            Debug.Log("アタッカーの勝ち");
            StartCoroutine(Destroy_me(block));
        }
        else if(attack_power > block_power)
        {
            Debug.Log("ブロッカーの勝ち");
            StartCoroutine(Destroy_me(attack));
        }
        else if(attack_power == block_power)
        {
            Debug.Log("引き分け");
            StartCoroutine(Destroy_me(attack));
            StartCoroutine(Destroy_me(block));
        }
        attack.GetComponent<CardController>().attack = false;
        block.GetComponent<CardController>().block = false;
        playerattack = false;
        enemyattack = false;
    }
}
