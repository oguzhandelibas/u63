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
        SelfImprovement
    }
    public LoseType loseType;

    [SerializeField] private GameObject[] academicLoseCards;

    public void Lose(LoseType _loseType)
    {
        GameManager.Instance.isGameContinue = false;
        foreach (GameObject item in academicLoseCards) item.SetActive(false);

        switch (_loseType)
        {
            case LoseType.Academic:
                academicLoseCards[0].SetActive(true);
                break;
            case LoseType.Network:
                academicLoseCards[1].SetActive(true);
                break;
            case LoseType.Experience:
                academicLoseCards[2].SetActive(true);
                break;
            case LoseType.SelfImprovement:
                academicLoseCards[3].SetActive(true);
                break;
        }
    }

    public void Win()
    {

    }
}
