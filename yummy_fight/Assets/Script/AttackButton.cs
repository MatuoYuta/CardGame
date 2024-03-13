using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public GameObject cardObject; // 横向きにするCardオブジェクト
    public GameDirecter _directer;
    public CardController _controller;
    private Button attackButton; // ボタンの参照
    public bool hirou;

    void Start()
    {
        _directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        _controller = cardObject.GetComponent<CardController>();
        // ボタンコンポーネントを取得
        attackButton = GetComponent<Button>();
        this.gameObject.SetActive(false);
    }

    public void OnAttackButtonClick()
    {
        Debug.Log("相手に攻撃した");
        cardObject.GetComponent<CardController>().attack = true;
        _controller.RotateCard(); // カードを横向きにするメソッドを呼び出す
        AttackPlayer(); // プレイヤーに攻撃するメソッドを呼び出す
        // ボタンを非表示にする
        gameObject.SetActive(false);
    }

    void AttackPlayer()
    {
        _directer.playerattack = true;
        if(_directer.EnemyFieldCardList.Length == 0)
        {
            cardObject.GetComponent<CardController>().attack = false;
            _directer.playerattack = false;
            _directer.enemy_life--;
        }

        //// プレイヤーオブジェクトをタグで検索して取得
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        //// プレイヤーオブジェクトが存在する場合
        //if (player != null)
        //{
        //    // プレイヤーオブジェクトにダメージを与えるなどの処理をここに記述
        //    // 以下はダメージを与える処理の例
        //    PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        //    if (playerHealth != null)
        //    {
        //        playerHealth.TakeDamage(1); // 例として10のダメージを与える
        //    }
        //}
        //else
        //{
        //    Debug.LogWarning("プレイヤーオブジェクトが見つかりませんでした！");
        //}

    }
}
