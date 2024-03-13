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

    //同名ターン１制限用変数
    public bool Buns, Patty,Muffin,Pickles,Foodraw,Plan,Stop;

    bool isPlayerTurn = true; //
    public List<int> deck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8, 1, 2 };  //

    void Awake()
    {
        // このゲームオブジェクトにアタッチされているPhotonViewコンポーネントを取得
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {   
        // シーンの自動同期を有効にする
        PhotonNetwork.AutomaticallySyncScene = true;
        StartGame();
    }

    void StartGame() // 初期値の設定 
    {
        // 初期手札を配る
        SetStartHand();

        
        // ターンの決定
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
                Debug.LogError("不明な場所: " + placeName);
                return;
        }

        CreateCard(cardID, placeTransform);
    }

    public void SummonCard(int cardID)
    {
        // ローカルプレイヤーのフィールドにカードを召喚
        CreateCard(cardID, playerField);

        // リモートプレイヤーのフィールドにもカードを表示するためにRPCを呼び出す
        photonView.RPC("CreateCardNetwork", RpcTarget.Others, cardID, "enemyField");
    }


    public void DrawCard(Transform hand) // カードを引く
    {
        // デッキがないなら引かない
        if (deck.Count == 0)
        {
            return;
        }

        // デッキの一番上のカードを抜き取り、手札に加える
        int cardID = deck[0];
        deck.RemoveAt(0);
        Debug.Log("ドロー！");
        CreateCard(cardID, hand);  
    }

    public void EnemyDraw()
    {
        //CreateCard()
    }

    void SetStartHand() // 手札を5枚配る
    {
        for (int i = 0; i < 5; i++)
        {
            DrawCard(playerHand);
        }
    }

    void TurnCalc() // ターンを管理する
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

    public void ChangeTurn() // ターンエンドボタンにつける処理
    {
        isPlayerTurn = !isPlayerTurn; // ターンを逆にする
        TurnCalc(); // ターンを相手に回す
        Buns = false;
        Patty = false;
        Muffin = false;
        Pickles = false;
    }

    void PlayerTurn()
    {
        Debug.Log("Playerのターン");

        DrawCard(playerHand); // 手札を一枚加える
    }

    void EnemyTurn()
    {
        Debug.Log("Enemyのターン");

        //CreateCard(1, enemyField); // カードを召喚

        ChangeTurn(); // ターンエンドする
    }
}