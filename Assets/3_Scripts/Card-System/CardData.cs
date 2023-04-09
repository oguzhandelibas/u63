using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/Card/CardData")]
public class CardData : ScriptableObject
{
    [Header("Is it for swiping left?")]
    public bool forLeft;

    [Header("Necessary task?")]
    public bool isRequired;

    [Header("Q&A")]
    public string cardText;
    public string[] answers;

    [Header("Indicator Values")]
    public int academicSuccess;
    public int network;
    public int experience;
    public int selfImprovment;

    [Header("How many days will it cost?")]
    public int dayCost;

    [Header("Card Design")]
    public string characterName;
    public Sprite characterImage;
    public Color backgroundColor;
}
