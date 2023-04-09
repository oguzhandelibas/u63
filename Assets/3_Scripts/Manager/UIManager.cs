using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public enum LoseType
    {
        Academic,
        Network,
        Experience,
        SelfImprovement,
        Requirement
    }
    public LoseType loseType;

    [SerializeField] private CardData[] loseCardDatas;
    [SerializeField] private CardData finalCard;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private GameObject confetti;

    private void Start()
    {
        confetti.SetActive(false);
    }

    public void UpdateDay(int dayCount)
    {
        if (dayCount <= 0)
        {
            dayCount = 0;
            Win();
        }
        dayText.text = "Akadem�de son " + dayCount + " g�n!";
    }

    public void Lose(LoseType _loseType)
    {
        GameManager.Instance.isGameContinue = false;
        GameManager.Instance.gameDone = true;
        CardData loseCardData = loseCardDatas[0];

        switch (_loseType)
        {
            case LoseType.Academic:
                loseCardData = loseCardDatas[0];
                break;
            case LoseType.Network:
                loseCardData = loseCardDatas[1];
                break;
            case LoseType.Experience:
                loseCardData = loseCardDatas[2];
                break;
            case LoseType.SelfImprovement:
                loseCardData = loseCardDatas[3];
                break;
            case LoseType.Requirement:
                loseCardData = loseCardDatas[4];
                break;
        }
        CardManager.Instance.CreateCard(loseCardData, true);
    }

    public void Win()
    {
        GameManager.Instance.gameDone = true;
        confetti.SetActive(true);
        CardManager.Instance.CreateCard(finalCard, true);
        finalCard.cardText = "G�r�nen o ki akademiyi ba�ar�yla tamamlad�n. Tebrikler :) \n Ba�ar� Oran�n: %" + IndicatorManager.Instance.FinalCalculation().ToString("F0");
    }
}
