using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    private RectTransform targetPanel; // 拡大表示する画像が表示されるパネル
    private GameObject currentCard; // 現在表示されているカードのインスタンス
    private const float ScaleFactor = 3f; // 画像の拡大倍率

    void Start()
    {
        // Kakudai パネルを検索して参照する
        GameObject kakudaiPanel = GameObject.Find("Kakudai");
        if (kakudaiPanel != null)
        {
            targetPanel = kakudaiPanel.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Kakudai Panel not found!");
        }

        // シーンにEventSystemがない場合は追加する
        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    // クリックされたときに呼ばれる関数
    public void OnPointerClick(PointerEventData eventData)
    {
        // クリックされた場所にオブジェクトがあるかチェック
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            // クリックされたオブジェクトがCardタグを持っているかチェック
            if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Card"))
            {
                // クリックされたオブジェクトに割り当てられているImageコンポーネントを取得
                Image cardImage = eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>();
                if (cardImage != null)
                {
                    Debug.Log("正常");
                    // 既存のCardPreviewが存在する場合は削除する
                    DestroyCurrentCardPreview();

                    // 拡大表示する画像のPrefabを生成
                    currentCard = new GameObject("CardPreview");
                    currentCard.transform.SetParent(targetPanel, false);
                    currentCard.tag = "kakudai";

                    // 生成されたPrefabにクリックされたオブジェクトの画像を設定
                    Image targetImage = currentCard.AddComponent<Image>();
                    targetImage.sprite = cardImage.sprite;

                    // 画像の大きさを3倍にする
                    RectTransform rectTransform = currentCard.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = new Vector2(cardImage.rectTransform.sizeDelta.x * 9f, cardImage.rectTransform.sizeDelta.y * 1.8f);
                }
                Debug.Log("処理終了");
            }
            else
            {
                Debug.Log("タグなし");
                // kakudaiタグのついたオブジェクトを破棄
                DestroyCurrentCardPreview();
            }
        }
        else
        {
            Debug.Log("オブジェクトなし");
            // kakudaiタグのついたオブジェクトを破棄
            DestroyCurrentCardPreview();
        }
    }

    // 現在のカードプレビューを削除するメソッド
    private void DestroyCurrentCardPreview()
    {
        GameObject[] kakudaiObjects = GameObject.FindGameObjectsWithTag("kakudai");

        foreach (GameObject obj in kakudaiObjects)
        {
            Destroy(obj);
            Debug.Log("削除処理");
        }

        currentCard = null;
    }
}
