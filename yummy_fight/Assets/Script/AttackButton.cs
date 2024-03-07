using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public GameObject cardObject; // 横向きにするCardオブジェクト
    private Quaternion originalRotation; // 元の回転を保存する変数
    private bool isRotated = false; // カードが回転しているかどうかを示すフラグ
    private Coroutine rotateCoroutine; // 回転を管理するコルーチン

    private void Start()
    {
        // カードオブジェクトの元の回転を保存
        originalRotation = cardObject.transform.rotation;
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
        isRotated = true; // カードが回転していることを示すフラグをtrueに設定
        // コルーチンを開始
        rotateCoroutine = StartCoroutine(ReturnToOriginalRotation());
    }

    IEnumerator ReturnToOriginalRotation()
    {
        // 一定時間待つ（スタンバイフェーズを想定）
        yield return new WaitForSeconds(2f);

        // カードが回転している場合は元の向きに戻す
        if (isRotated)
        {
            // カードオブジェクトの回転を元に戻す
            cardObject.transform.rotation = originalRotation;
            isRotated = false; // カードが回転していないことを示すフラグをfalseに設定
        }
    }

    // コルーチンを停止するメソッド
    private void StopRotateCoroutine()
    {
        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
        }
    }

    private void OnDestroy()
    {
        StopRotateCoroutine(); // オブジェクトが破棄される際にコルーチンを停止する
    }
}
