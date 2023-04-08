using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/Card/CardData")]
public class CardData : ScriptableObject
{
    public bool forLeft;

    public string cardText;
    public string[] answers;

    public int academicSuccess;
    public int network;
    public int experience;
    public int selfImprovment;

    public Sprite characterImage;
    public Color backgroundColor;
}
