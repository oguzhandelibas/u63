using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] private CardData[] cardDatas;
    [SerializeField] private GameObject cardObject;
    List<GameObject> cards = new List<GameObject>();
    private int currentIndex;
    public int CurrentIndex { get { return currentIndex; } set { currentIndex = value; } }

    private void Awake()
    {
        currentIndex = cardDatas.Length-1;
        for (int i = currentIndex; i >= 0; i--)
        {
            Card card = Instantiate(cardObject, transform).GetComponent<Card>();
            cards.Add(card.gameObject);
            card.gameObject.name = "Card " + (i+1);
            card.SetCard(this, cardDatas[i]);
            card.cardID = i+1;
            if (i != 0) card.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }

    public void ZoomNextCard(float distanceMoved)
    {
        if(currentIndex > 0 && Mathf.Abs(distanceMoved) > 0)
        {
            float step = Mathf.SmoothStep(0.8f, 1, Mathf.Abs(distanceMoved) / (Screen.width / 2));
            cards[currentIndex-1].transform.localScale = new Vector3(step, step, step);
        }
    }
}
