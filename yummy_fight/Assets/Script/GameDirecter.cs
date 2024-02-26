using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirecter : MonoBehaviour
{

    public Player1[] playerList;//�v���C���[�̃��X�g
    public bool Movable;//�����邩(�X�^���o�C�t�F�[�Y)
    public bool Summonable;//�����ł��邩(���C���t�F�[�Y)
    public bool Attackable;//�U���ł��邩�i�o�g���t�F�[�Y�j
    public GameObject phase_text;//�ǂ̃t�F�[�Y����\������

    public GameManager manage_script;

    public CardController[] playerFieldCardList;//�t�B�[���h�̃J�[�h���i�[���郊�X�g
    public CardController[] playerkitchenCardList;//������̃J�[�h���i�[���郊�X�g

    public enum Phase//�t�F�[�Y�Ǘ��p�񋓌^�ϐ�
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
        //�J�[�h�̃��X�g�i�[
        playerFieldCardList = manage_script.playerField.GetComponentsInChildren<CardController>();
        playerkitchenCardList = manage_script.playerKitchen.GetComponentsInChildren<CardController>();

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
