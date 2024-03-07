using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public GameObject cardObject; // 横向きにするCardオブジェクト
    public Button attackButton; // 攻撃ボタン

    void Start()
    {
        // ボタンを非表示にする
        attackButton.gameObject.SetActive(false);
    }

    public void OnAttackButtonClick()
    {
        Debug.Log("相手に攻撃した");
        RotateCard(); // カードを横向きにするメソッドを呼び出す
    }

    void RotateCard()
    {
        // カードを90度回転させる
        cardObject.transform.Rotate(new Vector3(0f, 0f, 90f));
    }
}
