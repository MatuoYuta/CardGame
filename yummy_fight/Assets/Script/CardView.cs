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
    public int power;

    public void Show(CardModel cardModel) // cardModelのデータ取得と反映
    {
        power = cardModel.power;
        this.gameObject.GetComponent<CardController>().default_power = power;
        powerText.GetComponent<TextMeshProUGUI>().text = power.ToString();
        iconImage.sprite = cardModel.icon;
    }
}