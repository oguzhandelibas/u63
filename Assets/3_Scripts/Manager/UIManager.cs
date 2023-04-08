using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Lose(LoseType _loseType)
    {
        GameManager.Instance.isGameContinue = false;
        CardData loseCardData = loseCardData = loseCardDatas[0];

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

        CardManager.Instance.CreateCard(loseCardData);
    }

    public void Win()
    {

    }
}
