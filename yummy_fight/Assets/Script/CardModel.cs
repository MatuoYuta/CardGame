using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class CardModel
{
    public int cardID;
    public int power;
    public Sprite icon;

    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);

        cardID = cardEntity.cardID;
        power = cardEntity.power;
        icon = cardEntity.icon;
    }
}