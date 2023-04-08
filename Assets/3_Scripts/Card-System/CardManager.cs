using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private CardData[] cardDatas;
    [SerializeField] private GameObject cardObject;

    private void Awake()
    {
        for (int i = cardDatas.Length-1; i >= 0; i--)
        {
            Card card = Instantiate(cardObject, transform).GetComponent<Card>();
            card.SetCard(cardDatas[i]);
        }
    }
}
