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
    public bool Zekkouhyoujun;//���x�߂������ł��邩
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

    public GameObject p_text, e_text,life_de_ukeru;
    public int turn;
    public bool main, battle;
    public int player_life, enemy_life;//�v���C���[�ƃG�l�~�[�̃��C�t
    public bool enemyattack,playerattack;

    public TextMeshProUGUI phaseText;// UI�e�L�X�g���A�T�C�����邽�߂̃p�u���b�N�ϐ�

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
        // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
        UpdatePhaseText();
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer+"\nInit";
        phase = Phase.DRAW;
    }
    void DrawPhase()
    {
        Debug.Log("DrawPhase");
        // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
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
        // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
        UpdatePhaseText();
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
        // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
        UpdatePhaseText();
        Summonable = true;
        phase_text.GetComponent<TextMeshProUGUI>().text = currentPlayer + "\nMain";
    }
    void BattlePhase()
    {
        Debug.Log("BattlePhase");
        // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
        UpdatePhaseText();
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
        // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
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

        // BATTLE�t�F�[�Y����o���̂ŃN���b�N���֎~����
        foreach (var objClickExample in FindObjectsOfType<ObjectClickExample>())
        {
            objClickExample.ExitBattlePhase();
        }
    }

    void Enemy_DrawPhase()
    {
        Debug.Log("Enemy_DrawPhase");
        // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
        UpdatePhaseText();
        phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nDraw";
        currentPlayer.EnemyDraw();
        phase = Phase.Enemy_STANDBY;
    }

    void Enemy_StandbyPhase()
    {
        Debug.Log("Enemy_StandbyPhase");
        // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
        UpdatePhaseText();
        phase_text.GetComponent<TextMeshProUGUI>().text = "Enemy" + "\nStandby";
        phase = Phase.Enemy_MAIN;
    }

    void Enemy_MainPhase()
    {
        if(main)
        {
            Debug.Log("Enemy_MainPhase");
            // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
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
            // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
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
        // �t�F�[�Y�ύX�ɔ����e�L�X�g�̍X�V
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

    void UpdatePhaseText()
    {
        Color enemyPhaseColor = Color.red;
        switch (phase)
        {
            // �v���C���[�t�F�[�Y�̏ꍇ�i�G�t�F�[�Y�łȂ����߁A�f�t�H���g�̐F���g�p�j
            case Phase.DRAW:
                phaseText.text = "Draw Phase";
                phaseText.color = Color.white; // �f�t�H���g�̐F�i�܂��̓v���C���[�̃t�F�[�Y�F�j
                break;
            case Phase.STANDBY:
                phaseText.text = "Standby Phase";
                phaseText.color = Color.white; // �f�t�H���g�̐F
                break;
            case Phase.MAIN:
                phaseText.text = "Main Phase";
                phaseText.color = Color.white; // �f�t�H���g�̐F
                break;
            case Phase.BATTLE:
                phaseText.text = "Battle Phase";
                phaseText.color = Color.white; // �f�t�H���g�̐F
                break;
            case Phase.END:
                phaseText.text = "End Phase";
                phaseText.color = Color.white; // �f�t�H���g�̐F
                break;

            // �G�̃t�F�[�Y�̏ꍇ�A�e�L�X�g�̐F��ԐF�ɐݒ�
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
                phaseText.color = Color.white; // �f�t�H���g�̐F
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
        Debug.Log("�o�g���J�n");
        Debug.Log("�A�^�b�N�p���[" + attack_power);
        Debug.Log("�u���b�N�p���[" + block_power);
        if (attack_power > block_power)
        {
            Debug.Log("�A�^�b�J�[�̏���");
            StartCoroutine(Destroy_me(block));
        }
        else if(attack_power > block_power)
        {
            Debug.Log("�u���b�J�[�̏���");
            StartCoroutine(Destroy_me(attack));
        }
        else if(attack_power == block_power)
        {
            Debug.Log("��������");
            StartCoroutine(Destroy_me(attack));
            StartCoroutine(Destroy_me(block));
        }
        attack.GetComponent<CardController>().attack = false;
        block.GetComponent<CardController>().block = false;
        playerattack = false;
        enemyattack = false;
    }
}
