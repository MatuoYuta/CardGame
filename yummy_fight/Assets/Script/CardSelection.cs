using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public GameObject attackButton;

    public bool cardSelected = false;

    void Start()
    {
        // 最初は攻撃ボタンを非表示にする
        attackButton.gameObject.SetActive(false);
    }

    void Update()
    {
        // マウスの左クリックが押されたかどうかを確認し、カードがクリックされた場合にフラグを設定する
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 ray2D = new Vector2(ray.origin.x, ray.origin.y);
            RaycastHit2D hit2D = Physics2D.Raycast(ray2D, Vector2.zero);
            if (hit2D.collider != null && hit2D.collider.gameObject.CompareTag("Card"))
            {
                cardSelected = (true);
            }
        }

        // カードが選択されているかどうかを確認し、攻撃ボタンの表示状態を更新する
        if (cardSelected)
        {
            attackButton.gameObject.SetActive(true);
        }
        else
        {
            attackButton.gameObject.SetActive(false);
        }
    }
}