using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : Singleton<CardManager>
{
    [SerializeField] private Vector2[] tuple;

    [SerializeField] private List<CardData> randomCardDatas;
    [SerializeField] private CardData[] necessaryCardDatas;

    [SerializeField] private Transform cardsParent;
    [SerializeField] private GameObject cardObject;
    public List<GameObject> cards = new List<GameObject>();

    [SerializeField] private GameObject[] indicators;

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

    public void ShowIndicator()
    {
        StartCoroutine(ShowIndicatorRoutine());
    }

    IEnumerator ShowIndicatorRoutine()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < indicators.Length; i++)
        {
            indicators[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = indicators.Length-1; i >= 0; i--)
        {
            indicators[i].SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
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

    public Card CreateCard(CardData cardData = null, bool isLastCard = false)
    {
        currentIndex++;

        if (totalCardCount == currentIndex) 
        {
            GameManager.Instance.isGameContinue = false;
            UIManager.Instance.Win();
            return null;
        } 
            
        CheckNecessaryCard();

        if (isLastCard)
        {
            foreach (var item in cards)
            {
                item.SetActive(false);
            }
            
            Card lastCard = Instantiate(cardObject, cardsParent).GetComponent<Card>();
            lastCard.transform.localScale = new Vector3(1, 1, 1);
            lastCard.cardText.gameObject.SetActive(true);
            lastCard.transform.SetSiblingIndex(2);
            lastCard.SetCard(this, cardData);
            return lastCard;
        }
        else
        {
            if (necessaryIndex > necessaryCardDatas.Length - 1) return null;

            Card card = Instantiate(cardObject, cardsParent).GetComponent<Card>();
            card.transform.SetSiblingIndex(0);
            cards.Add(card.gameObject);


            if (!necessaryCardTime)
            {
                CreateRandomCard(card, cardData);
                return card;
            }

            if (currentIndex + 1 == 4) ShowIndicator();

            card.gameObject.name = "Necessary Card " + (necessaryIndex);
            if (cardData == null) cardData = necessaryCardDatas[necessaryIndex];
            card.cardID = currentIndex + 1;
            
            card.SetCard(this, cardData);

            if (card.gameObject != cards[0]) card.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            necessaryIndex++;
            if (GameManager.Instance.gameDone) card.gameObject.SetActive(false);
            return card;
        }
    }

    private void CreateRandomCard(Card card, CardData cardData)
    {
        card.gameObject.name = "Random Card";
        int a = Random.Range(0, randomCardDatas.Count);
        if (cardData == null) cardData = randomCardDatas[a];
        randomCardDatas.RemoveAt(a);
        card.cardID = currentIndex + 1;
        card.SetCard(this, cardData);
        if (card.gameObject != cards[0]) card.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    public void ZoomNextCard(float distanceMoved)
    {
        if (cards.Count > 1 && currentIndex <= tuple[tuple.Length-1].y && Mathf.Abs(distanceMoved) > 0)
        {
            float step = Mathf.SmoothStep(0.8f, 1, Mathf.Abs(distanceMoved) / (Screen.width / 4f));
            cards[1].transform.localScale = new Vector3(step, step, step);
        }  
    }
}
