using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] CardController cardPrefab;
    public Transform playerHand, playerField,playerKitchen, enemyHand, enemyField,enemyKitchen;
    public GameObject select_panel;
    GameObject clickedGameObject;

    //同名ターン１制限用変数
    public bool Buns, Patty;

    bool isPlayerTurn = true; //
    public List<int> deck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8, 1, 2 };  //

    void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }

            Debug.Log(clickedGameObject);
        }
    }

    void StartGame() // 初期値の設定 
    {
        // 初期手札を配る
        SetStartHand();

        CreateCard(2, enemyField);
        CreateCard(2, enemyField);
        CreateCard(2, enemyField);
        // ターンの決定
        TurnCalc();
    }

    public void CreateCard(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
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
    }

    void PlayerTurn()
    {
        Debug.Log("Playerのターン");

        DrawCard(playerHand); // 手札を一枚加える
    }

    void EnemyTurn()
    {
        Debug.Log("Enemyのターン");

        CreateCard(1, enemyField); // カードを召喚

        ChangeTurn(); // ターンエンドする
    }
}