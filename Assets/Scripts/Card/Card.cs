﻿using System;
using UnityEngine;


//[CreateAssetMenu(fileName ="New card",menuName ="Card")]
[Serializable]
public class Card //: ScriptableObject
{
    public string name;
 
    public string cardID;

    public CardTypes cardType;

    public Affect affect; //need work on it;

    public string affectDescription;

    public int actionPoint;

    public Rarity rarity;

    public CardUIType cardBelonging = CardUIType.defaultCard;

    private static int id;

    public Card(string cardName, CardTypes cardType, Affect affect, string affectDescription, int actionPoint, Rarity rarity, CardUIType cardBelonging)
    {
        id++;
        cardID = cardName.ToLower() + $"_{id}";//Guid.NewGuid().ToString("N");
        //Debug.Log(cardID);
        name = cardName;
        this.cardType = cardType;
        this.affect = affect;
        this.affectDescription = affectDescription;
        this.actionPoint = actionPoint;
        this.rarity = rarity;
        this.cardBelonging = cardBelonging;
    }
}