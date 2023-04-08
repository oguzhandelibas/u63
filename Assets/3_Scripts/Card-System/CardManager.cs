using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : Singleton<CardManager>
{
    [SerializeField] private Vector2[] tuple;

    [SerializeField] private CardData[] randomCardDatas;
    [SerializeField] private CardData[] necessaryCardDatas;

    [SerializeField] private Transform cardsParent;
    [SerializeField] private GameObject cardObject;
    public List<GameObject> cards = new List<GameObject>();

    public bool necessaryCardTime = true;
    public int tupleIndex = 0;
    public int currentIndex;
    public int necessaryIndex = 0;
    private int totalCardCount;

    private void Start()
    {
        totalCardCount = (int)tuple[tuple.Length - 1].y;
        necessaryCardTime = true;
        tupleIndex = 0;
        currentIndex = -1;
        CreateCard(); 
        CreateCard();
    }

    public void RemoveCard(GameObject cardObj)
    {
        cards.Remove(cardObj);
    }

    private void CheckNecessaryCard()
    {
        if(tupleIndex >= tuple.Length)
        {
            GameManager.Instance.isGameContinue = false;
            UIManager.Instance.Win();
            necessaryCardTime = false;
            return;
        } 

        if(currentIndex == tuple[tupleIndex].x && tuple[tupleIndex].y == 0)
        {
            necessaryCardTime = true;
            //tupleIndex++;
        }
        else if (Mathf.Clamp(currentIndex, tuple[tupleIndex].x, tuple[tupleIndex].y) == currentIndex)
        {
            necessaryCardTime = true;
        }
        else
        {
            if (necessaryCardTime) tupleIndex++;
            necessaryCardTime = false;
        }
    }

    public Card CreateCard(CardData cardData = null)
    {
        currentIndex++;

        if (totalCardCount == currentIndex) 
        {
            GameManager.Instance.isGameContinue = false;
            UIManager.Instance.Win();
            return null;
        } 
            
        CheckNecessaryCard();

        Card card = Instantiate(cardObject, cardsParent).GetComponent<Card>();
        card.transform.SetSiblingIndex(0);
        cards.Add(card.gameObject);
        

        if (!necessaryCardTime)
        {
            CreateRandomCard(card, cardData);
            return card;
        }

        
        card.gameObject.name = "Necessary Card " + (necessaryIndex);
        if (cardData == null) cardData = necessaryCardDatas[necessaryIndex];
        card.cardID = currentIndex + 1;
        card.SetCard(this, cardData);
        
        if (card.gameObject != cards[0]) card.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        necessaryIndex++;

        return card;
        
    }

    private void CreateRandomCard(Card card, CardData cardData)
    {
        card.gameObject.name = "Random Card";
        if (cardData == null) cardData = randomCardDatas[Random.Range(0,randomCardDatas.Length)];
        card.cardID = currentIndex + 1;
        card.SetCard(this, cardData);
        if (card.gameObject != cards[0]) card.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    public void ZoomNextCard(float distanceMoved)
    {
        Debug.Log(cards.Count > 1);
        Debug.Log(currentIndex <= tuple[tuple.Length - 1].y);
        Debug.Log(Mathf.Abs(distanceMoved));
        if (cards.Count > 1 && currentIndex <= tuple[tuple.Length-1].y && Mathf.Abs(distanceMoved) > 0)
        {
            float step = Mathf.SmoothStep(0.8f, 1, Mathf.Abs(distanceMoved) / (Screen.width / 2));
            cards[1].transform.localScale = new Vector3(step, step, step);
        }
    }
}
