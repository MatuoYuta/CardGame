using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] CardController cardPrefab;
    [SerializeField] public Transform playerHand, playerField,playerKitchen, enemyField;

    bool isPlayerTurn = true; //
    List<int> deck = new List<int>() { 1, 2, 101, 1, 1, 2, 2, 101, 101, 1, 2, 101, 1, 2, 101, 1, 2, 101 };  //

    void Start()
    {
        StartGame();
    }

    void StartGame() // �����l�̐ݒ� 
    {
        // ������D��z��
        SetStartHand();

        CreateCard(2, enemyField);
        CreateCard(2, enemyField);
        CreateCard(2, enemyField);
        // �^�[���̌���
        TurnCalc();
    }

    void CreateCard(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
    }

    public void DrawCard(Transform hand) // �J�[�h������
    {
        // �f�b�L���Ȃ��Ȃ�����Ȃ�
        if (deck.Count == 0)
        {
            return;
        }

        // �f�b�L�̈�ԏ�̃J�[�h�𔲂����A��D�ɉ�����
        int cardID = deck[0];
        deck.RemoveAt(0);
        Debug.Log("�h���[�I");
        CreateCard(cardID, hand);
    }

    void SetStartHand() // ��D��5���z��
    {
        for (int i = 0; i < 5; i++)
        {
            DrawCard(playerHand);
        }
    }

    void TurnCalc() // �^�[�����Ǘ�����
    {
        if (isPlayerTurn)
        {
           //PlayerTurn();
        }
        else
        {
            EnemyTurn();
        }
    }

    public void ChangeTurn() // �^�[���G���h�{�^���ɂ��鏈��
    {
        isPlayerTurn = !isPlayerTurn; // �^�[�����t�ɂ���
        TurnCalc(); // �^�[���𑊎�ɉ�
    }

    void PlayerTurn()
    {
        Debug.Log("Player�̃^�[��");

        DrawCard(playerHand); // ��D���ꖇ������
    }

    void EnemyTurn()
    {
        Debug.Log("Enemy�̃^�[��");

        CreateCard(1, enemyField); // �J�[�h������

        ChangeTurn(); // �^�[���G���h����
    }
}