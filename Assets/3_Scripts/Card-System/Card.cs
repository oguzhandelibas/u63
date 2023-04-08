using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public int cardID;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private CardData cardData;

    [SerializeField] private TextMeshProUGUI cardText;
    [SerializeField] private TextMeshProUGUI[] answers;

    [SerializeField] private Image background;
    [SerializeField] private Image characterImage;

    private void Start()
    {
        SetSwipeObjectActiveness(false,false);
    }

    public void OnSwipe()
    {
        cardManager.ZoomNextCard(transform.localPosition.x);
    }

    public void Swipe(bool left)
    {
        cardManager.CurrentIndex -= 1;
        if(cardData.isRequired)
        {
            if (cardData.forLeft == left)
            {
                //sorun yok
                Change(cardData.academicSuccess, cardData.network, cardData.experience, cardData.selfImprovment);
                Debug.Log("DEVAM");
            }
            else
            {
                Debug.Log("ATILDIN!");
            }
        }
        else
        {
            Change(cardData.academicSuccess, cardData.network, cardData.experience, cardData.selfImprovment);
        }
        
    }

    public void Change(int a, int b, int c, int d)
    {

    }
    public void SetCard(CardManager _cardManager, CardData _cardData)
    {
        cardData = _cardData;
        cardManager = _cardManager;
        cardText.text = cardData.cardText;
        answers[0].text = cardData.answers[0];
        answers[1].text = cardData.answers[1];

        background.color = cardData.backgroundColor;
        characterImage.sprite = cardData.characterImage;
    }

    public void SetSwipeObjectActiveness(bool value1, bool value2)
    {
        answers[0].gameObject.SetActive(value1);
        answers[1].gameObject.SetActive(value2);
    }
}
