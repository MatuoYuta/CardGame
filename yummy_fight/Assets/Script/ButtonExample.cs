using UnityEngine;
using UnityEngine.UI;

public class ButtonExample : MonoBehaviour
{
    public GameObject button;

    void Start()
    {
        // Buttonのインスタンスを取得して、非表示に設定する
        button.gameObject.SetActive(false);
    }

    // ボタンがクリックされたときに実行されるメソッド
    public void ButtonClicked()
    {
        Debug.Log("Button clicked!");
    }

    // オブジェクトが選択されたときに実行されるメソッド
    private void OnMouseDown()
    {
        // ボタンを表示する
        button.gameObject.SetActive(true);
    }
}