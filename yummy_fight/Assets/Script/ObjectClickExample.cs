using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectClickExample : MonoBehaviour, IPointerClickHandler
{
    public GameObject buttonToToggle; // 表示/非表示を切り替えるボタン

    public CardController _controller;
    public ObjectHighlight _hilight;

    private bool canClick = false; // クリックを許可するかどうかのフラグ

    void Start()
    {
        _controller = this.gameObject.GetComponent<CardController>();
        _hilight = this.gameObject.GetComponent<ObjectHighlight>();
    }

    // クリックされたときに呼び出されるメソッド
    public void OnPointerClick(PointerEventData eventData)
    {
        if (canClick)
        {
            // クリックされたオブジェクトがPlayer_field上にあるcardオブジェクトであるかチェック
            if (transform.IsChildOf(GameObject.Find("Player_field").transform) && transform.CompareTag("Card"))
            {
                // ボタンがnullでなければ、表示/非表示を切り替える
                if (buttonToToggle != null)
                {
                    if(!_hilight.selected && !_controller.hirou)
                    {
                        buttonToToggle.SetActive(true);
                    }
                    else
                    {
                        buttonToToggle.SetActive(false);
                    }
                    
                    //if (!_controller.hirou)
                    //{
                    //    // ボタンの表示状態を反転させる
                    //    buttonToToggle.SetActive(!buttonToToggle.activeSelf);
                    //}

                    // 表示/非表示を切り替えたことをコンソールに表示
                    if (buttonToToggle.activeSelf)
                    {
                        print($"オブジェクト {name} がクリックされたよ！ボタンが表示されました。");
                    }
                    else
                    {
                        print($"オブジェクト {name} がクリックされたよ！ボタンが非表示になりました。");
                    }
                }
            }
        }
    }

    // BATTLEフェーズに入ったときに呼び出されるメソッド
    public void EnterBattlePhase()
    {
        canClick = true; // クリックを許可する
    }

    // BATTLEフェーズから出たときに呼び出されるメソッド
    public void ExitBattlePhase()
    {
        canClick = false; // クリックを禁止する

        // ボタンが表示されている場合は非表示にする
        if (buttonToToggle != null && buttonToToggle.activeSelf)
        {
            buttonToToggle.SetActive(false);
            print($"BATTLEフェーズから出たので、ボタンを非表示にしました。");
        }
    }
}
