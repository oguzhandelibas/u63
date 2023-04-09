using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [HideInInspector] public Card nextCard;
    public int cardID;
    public CardManager cardManager;
    [SerializeField] private CardData cardData;

    public TextMeshProUGUI cardText;
    [SerializeField] private TextMeshProUGUI[] answers;
    [SerializeField] private TextMeshProUGUI characterName;

    public Image shadow;
    [SerializeField] private Image background;
    [SerializeField] private Image characterImage;

    private void Start()
    {
        SetSwipeObjectActiveness(false,false);
    }

    public void RemoveCard()
    {
        cardManager.RemoveCard(gameObject);
    }

    public void CreateNextCard()
    {
        nextCard = cardManager.CreateCard();
        
    }

    public void OnSwipe()
    {
        cardManager.ZoomNextCard(transform.GetChild(0).localPosition.x);
    }

    public void Swipe(bool left)
    {
        if (!GameManager.Instance.isGameContinue) return;
        GameManager.Instance.SetDayStatus(cardData.dayCost);
        if (cardData.isRequired)
        {
            if (cardData.forLeft == left)
            {
                IndicatorManager.Instance.Change(cardData.academicSuccess, cardData.network, cardData.experience, cardData.selfImprovment);
            }
            else
            {
                UIManager.Instance.Lose(UIManager.LoseType.Requirement);
            }
        }
        else
        {
            if (cardData.forLeft)
            {
                if(left) IndicatorManager.Instance.Change(cardData.academicSuccess, cardData.network, cardData.experience, cardData.selfImprovment);
                else IndicatorManager.Instance.Change(-cardData.academicSuccess, -cardData.network, -cardData.experience, -cardData.selfImprovment);
            }
            else
            {
                if (!left) IndicatorManager.Instance.Change(cardData.academicSuccess, cardData.network, cardData.experience, cardData.selfImprovment);
                else IndicatorManager.Instance.Change(-cardData.academicSuccess, -cardData.network, -cardData.experience, -cardData.selfImprovment);
            }
        }

        CreateNextCard();

    }

    public void SetCard(CardManager _cardManager, CardData _cardData)
    {
        
        cardData = _cardData;
        cardManager = _cardManager;
        cardText.text = cardData.cardText;
        answers[0].text = cardData.answers[0];
        answers[1].text = cardData.answers[1];

        if (cardData.characterName != null) characterName.text = cardData.characterName;

        background.color = cardData.backgroundColor;
        characterImage.sprite = cardData.characterImage;

        if (cardID == 1) cardText.gameObject.SetActive(true);
    }

    public void SetSwipeObjectActiveness(bool value1, bool value2)
    {
        answers[0].gameObject.SetActive(value1);
        answers[1].gameObject.SetActive(value2);
    }

    public void IndicatorCircleActivenessValue()
    {

    }
}
