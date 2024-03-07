using UnityEngine;

public class ResetCardRotation : MonoBehaviour
{
    // StandbyPhase時に呼び出される関数
    public void OnStandbyPhase()
    {
        // Player_fieldの子要素すべてに対して処理を行う
        foreach (Transform cardTransform in transform)
        {
            // カードのTransformコンポーネントのrotationをリセットする
            cardTransform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
