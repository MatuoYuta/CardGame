using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    // 攻撃ボタン
    public Button attackButton;

    // カードが選択されたときに呼ばれる関数
    public void OnCardSelected()
    {
        // カードが選択された場合、攻撃ボタンを表示する
        attackButton.gameObject.SetActive(true);
    }
}
