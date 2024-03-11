using UnityEngine;
using UnityEngine.UI;

public class AttackActionPanel : MonoBehaviour
{
    public GameObject blockButton; // ブロックするボタン
    public GameObject lifeButton; // ライフで受けるボタン

    void Start()
    {
        // 初期状態ではボタンを非表示にする
        blockButton.SetActive(false);
        lifeButton.SetActive(false);
    }

    // ボタンを表示するメソッド
    public void ShowButtons()
    {
        blockButton.SetActive(true);
        lifeButton.SetActive(true);
    }

    // ボタンを非表示にするメソッド
    public void HideButtons()
    {
        blockButton.SetActive(false);
        lifeButton.SetActive(false);
    }
}
