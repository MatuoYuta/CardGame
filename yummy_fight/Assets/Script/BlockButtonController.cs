using UnityEngine;
using UnityEngine.UI;

/*public class BlockButtonController : MonoBehaviour
{
    public GameObject blockButton; // ブロックするボタンのUIオブジェクト
    public GameObject lifeButton; // ライフで受けるボタンのUIオブジェクト

    private bool buttonsVisible = false; // ボタンの表示状態

    void Start()
    {
        // 初期状態ではボタンを非表示にする
        SetButtonsVisible(false);
    }

    // ボタンの表示状態を設定するメソッド
    void SetButtonsVisible(bool visible)
    {
        blockButton.SetActive(visible);
        lifeButton.SetActive(visible);
        buttonsVisible = visible;
    }

    // 攻撃ボタンが押された時の処理
    public void OnAttackButtonClicked()
    {
        // バトルフェーズ中かつ相手が攻撃をしている場合、ボタンを表示する
        if (BattleManager.Instance.IsInBattlePhase && BattleManager.Instance.IsOpponentAttacking)
        {
            SetButtonsVisible(true);
        }
    }

    // ブロックするボタンが押された時の処理
    public void OnBlockButtonClicked()
    {
        // ここにブロックする処理を実装する
        Debug.Log("Blocked!");
        SetButtonsVisible(false);
    }

    // ライフで受けるボタンが押された時の処理
    public void OnLifeButtonClicked()
    {
        // ここにライフで受ける処理を実装する
        Debug.Log("Life!");
        SetButtonsVisible(false);
    }
}*/
