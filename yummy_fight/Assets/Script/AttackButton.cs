using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public GameObject cardObject; // 横向きにするCardオブジェクト
    private Button attackButton; // ボタンの参照

    void Start()
    {
        // ボタンコンポーネントを取得
        attackButton = GetComponent<Button>();
    }

    public void OnAttackButtonClick()
    {
        Debug.Log("相手に攻撃した");
        RotateCard(); // カードを横向きにするメソッドを呼び出す
        // ボタンを非表示にする
        gameObject.SetActive(false);
    }

    void RotateCard()
    {
        // カードを90度回転させる
        cardObject.transform.Rotate(new Vector3(0f, 0f, 90f));
    }
}
