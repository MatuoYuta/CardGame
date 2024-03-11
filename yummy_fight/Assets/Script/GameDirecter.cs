using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameDirecter : MonoBehaviour
{

    public Player1[] playerList;//�v���C���[�̃��X�g
    public bool Movable;//�����邩(�X�^���o�C�t�F�[�Y)
    public bool Summonable;//�����ł��邩(���C���t�F�[�Y)
    public bool Attackable;//�U���ł��邩�i�o�g���t�F�[�Y�j
    public GameObject phase_text;//�ǂ̃t�F�[�Y����\������

    public GameManager manage_script;
    public CPU cpu_script;
    public GameObject before_outline;
    public GameObject before_outline_object;

    public CardController[] playerHandCardList;//�v���C���[�̎�D���i�[���郊�X�g
    public CardController[] playerFieldCardList;//�t�B�[���h�̃J�[�h���i�[���郊�X�g
    public CardController[] playerkitchenCardList;//������̃J�[�h���i�[���郊�X�g
    public CardController[] enemyHandCardList;//�G�̎�D���i�[���郊�X�g
    public CardController[] EnemyKitchenCardList;//�G�̒�����̃J�[�h���i�[���郊�X�g
    public CardController[] EnemyFieldCardList;//�G�̃t�B�[���h�̃J�[�h���i�[���郊�X�g

    public ObjectHighlight[] SearchImageList;//�T�[�`����J�[�h

    public int turn;
    public bool main, battle;

    public enum Phase//�t�F�[�Y�Ǘ��p�񋓌^�ϐ�
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
        //�J�[�h�̃��X�g�i�[
        playerHandCardList = manage_script.playerHand.GetComponentsInChildren<CardController>();
        playerFieldCardList = manage_script.playerField.GetComponentsInChildren<CardController>();
        playerkitchenCardList = manage_script.playerKitchen.GetComponentsInChildren<CardController>();

        enemyHandCardList = manage_script.enemyHand.GetComponentsInChildren<CardController>();
        EnemyFieldCardList = manage_script.enemyField.GetComponentsInChildren<CardController>();
        EnemyKitchenCardList = manage_script.enemyKitchen.GetComponentsInChildren<CardController>();

        SearchImageList = manage_script.searchArea.GetComponentsInChildren<ObjectHighlight>();


        switch (phase)
        {
            case Phase.INIT://�����t�F�[�Y
                currentPlayer = playerList[0];
                InitPhase();
                break;
            case Phase.DRAW://�h���[�t�F�[�Y
                DrawPhase();
                break;
            case Phase.STANDBY://�X�^���o�C�i�ړ��j�t�F�[�Y
                StandbyPhase();
                break;
            case Phase.MAIN://�X�^���o�C�i�ړ��j�t�F�[�Y
                MainPhase();
                break;
            case Phase.BATTLE://�o�g���t�F�[�Y
                BattlePhase();
                break;
            case Phase.END://�G���h�t�F�[�Y
                EndPhase();
                break;
            case Phase.Enemy_DRAW://�h���[�t�F�[�Y
                turn++;
                Enemy_DrawPhase();
                break;
            case Phase.Enemy_STANDBY://�X�^���o�C�i�ړ��j�t�F�[�Y
                Enemy_StandbyPhase();
                break;
            case Phase.Enemy_MAIN://���C���t�F�[�Y
                Enemy_MainPhase();
                break;
            case Phase.Enemy_BATTLE://�o�g���t�F�[�Y
                Enemy_BattlePhase();
                break;
            case Phase.Enemy_END://�G���h�t�F�[�Y
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

        // StandbyPhase�ɓ������Ƃ��ɃJ�[�h�̌��������Z�b�g
        ResetCardRotation(playerFieldCardList);
    }

    // Player_field�ɂ���J�[�h�̌��������Z�b�g����֐�
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

        // BATTLE�t�F�[�Y�ɓ������̂ŃN���b�N��������
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

        // BATTLE�t�F�[�Y����o���̂ŃN���b�N���֎~����
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
            case Phase.STANDBY://�X�^���o�C�i�ړ��j�t�F�[�Y
                phase = Phase.MAIN;
                break;
            case Phase.MAIN://���C���t�F�[�Y
                phase = Phase.BATTLE;
                break;
            case Phase.BATTLE://�o�g���t�F�[�Y
                phase = Phase.END;
                break;
        }
    }
}
