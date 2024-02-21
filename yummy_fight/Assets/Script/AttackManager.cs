using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    public GameObject attackButton; // 攻撃ボタンのGameObject
    public GameObject selectedCard; // 選択されたカードのGameObject

    void Start()
    {
        attackButton.SetActive(false); // ゲーム開始時は攻撃ボタンを非表示にする
    }

    void Update()
    {
        // カードが選択されているかどうかを確認し、攻撃ボタンを表示する
        if (selectedCard != null && IsCardInBattleZone(selectedCard))
        {
            attackButton.SetActive(true);
        }
        else
        {
            attackButton.SetActive(false);
        }
    }

    // カードがバトルゾーンにあるかどうかを判定する関数
    bool IsCardInBattleZone(GameObject card)
    {
        // ここにバトルゾーンに関する判定処理を実装する
        // 例えば、カードが特定の領域内にあるかどうかを確認するなど
        return true; // 仮の実装として常にtrueを返す
    }

    // カードが選択されたときに呼び出される関数
    public void CardSelected(GameObject selectedCard)
    {
        this.selectedCard = selectedCard;
    }

    // 攻撃ボタンが押されたときに呼び出される関数
    public void AttackButtonClicked()
    {
        // ここに攻撃の処理を実装する
    }
}
