using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private CardData cardData;

    [SerializeField] private TextMeshProUGUI cardText;
    [SerializeField] private TextMeshProUGUI[] answers;

    [SerializeField] private Image background;
    [SerializeField] private Image characterImage;

    private void Start()
    {
        SetSwipeObjectActiveness(false);
    }

    public void Swipe()
    {
        Debug.Log("Swipe Edildi!!!");
    }

    public void SetCard(CardData _cardData)
    {
        cardData = _cardData;
        cardText.text = cardData.cardText;
        answers[0].text = cardData.answers[0];
        answers[1].text = cardData.answers[1];

        background.color = cardData.backgroundColor;
        characterImage.sprite = cardData.characterImage;
    }

    public void SetSwipeObjectActiveness(bool value)
    {
        foreach (var item in answers)
        {
            item.gameObject.SetActive(value);
        }
    }
}
