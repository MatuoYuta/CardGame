using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI powerText;
    [SerializeField] Image iconImage;
    public int cardID;

    public void Show(CardModel cardModel) // cardModelのデータ取得と反映
    {
        powerText.GetComponent<TextMeshProUGUI>().text = cardModel.power.ToString();
        iconImage.sprite = cardModel.icon;
    }
}