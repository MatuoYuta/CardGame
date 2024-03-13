using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameManager : MonoBehaviour
{
    [SerializeField] CardController cardPrefab;
    [SerializeField] private HandCardsInfoSync handCardsInfoSync;
    public Transform playerHand, playerField,playerKitchen, enemyHand, enemyField,enemyKitchen,searchArea;
    public GameObject select_panel;
    private PhotonView photonView;

    //�����^�[���P�����p�ϐ�
    public bool Buns, Patty,Muffin,Pickles,Foodraw,Plan,Stop;

    bool isPlayerTurn = true; //
    public List<int> deck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8, 1, 2 };  //

    void Awake()
    {
        // ���̃Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă���PhotonView�R���|�[�l���g���擾
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {   
        // �V�[���̎���������L���ɂ���
        PhotonNetwork.AutomaticallySyncScene = true;
        StartGame();
    }

    void StartGame() // �����l�̐ݒ� 
    {
        // ������D��z��
        SetStartHand();

        
        // �^�[���̌���
        TurnCalc();
    }

    public void CreateCard(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
    }



    [PunRPC]
    public void CreateCardNetwork(int cardID, string placeName)
    {
        Transform placeTransform;
        switch (placeName)
        {
            case "playerField":
                placeTransform = playerField;
                break;
            case "enemyField":
                placeTransform = enemyField;
                break;
            default:
                Debug.LogError("�s���ȏꏊ: " + placeName);
                return;
        }

        CreateCard(cardID, placeTransform);
    }

    public void SummonCard(int cardID)
    {
        // ���[�J���v���C���[�̃t�B�[���h�ɃJ�[�h������
        CreateCard(cardID, playerField);

        // �����[�g�v���C���[�̃t�B�[���h�ɂ��J�[�h��\�����邽�߂�RPC���Ăяo��
        photonView.RPC("CreateCardNetwork", RpcTarget.Others, cardID, "enemyField");
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

    public void EnemyDraw()
    {
        //CreateCard()
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
        Buns = false;
        Patty = false;
        Muffin = false;
        Pickles = false;
    }

    void PlayerTurn()
    {
        Debug.Log("Player�̃^�[��");

        DrawCard(playerHand); // ��D���ꖇ������
    }

    void EnemyTurn()
    {
        Debug.Log("Enemy�̃^�[��");

        //CreateCard(1, enemyField); // �J�[�h������

        ChangeTurn(); // �^�[���G���h����
    }
}