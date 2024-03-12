using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public CardView view; // カードの見た目の処理
    public CardModel model; // カードのデータを処理
    public bool hirou;
    GameDirecter _directer;

    private void Awake()
    {
        view = GetComponent<CardView>();
        hirou = false;
        _directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
    }

    public void Init(int cardID) // カードを生成した時に呼ばれる関数
    {
        Debug.Log(cardID);
        view.cardID = cardID;
        model = new CardModel(cardID); // カードデータを生成
        view.Show(model); // 表示
    }
    public void Destroy_me()
    {
        Destroy(this.gameObject);
    }

    public void RotateCard()
    {
        // カードを90度回転させる
        this.transform.Rotate(new Vector3(0f, 0f, 90f));
        this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
        hirou = true;
    }

    public void enemyattack()
    {
        // カードを90度回転させる
        this.transform.Rotate(new Vector3(0f, 0f, -90f));
        this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
        hirou = true;

        _directer.enemyattack = true;
    }

    public void enemyblock()
    {
        // カードを90度回転させる
        this.transform.Rotate(new Vector3(0f, 0f, -90f));
        this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
        hirou = true;

        _directer.enemyattack = true;
    }

    public void kaihuku()
    {
        if (hirou)
        {
            // カードを90度回転させる
            this.transform.Rotate(new Vector3(0f, 0f, -90f));
            this.transform.localScale = new Vector3(1.3f, 2f, 1.3f);
            hirou = false;
        }
    }
}