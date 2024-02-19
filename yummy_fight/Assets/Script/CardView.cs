using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI powerText;
    [SerializeField] Image iconImage;

    public void Show(CardModel cardModel) // cardModel�̃f�[�^�擾�Ɣ��f
    {
        powerText.GetComponent<TextMeshProUGUI>().text = cardModel.power.ToString();
        iconImage.sprite = cardModel.icon;
    }
}