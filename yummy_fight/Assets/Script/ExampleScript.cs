using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public Camera camera;

    void Start()
    {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            Transform objectHit = hit.transform;
            // レイに当たったオブジェクトに何かをする
            if (objectHit.CompareTag("Card"))
            {
                // カードオブジェクトにアタッチされているButtonExampleスクリプトを取得
                ButtonExample buttonExample = objectHit.GetComponent<ButtonExample>();

                // ButtonExampleスクリプトが存在し、有効であれば処理を呼び出す
                if (buttonExample != null && buttonExample.enabled)
                {
                    buttonExample.ButtonClicked();
                }
            }
        }
    }
}
