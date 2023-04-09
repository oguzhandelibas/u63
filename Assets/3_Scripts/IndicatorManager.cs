using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : Singleton<IndicatorManager>
{
    public Image academicImage, networkImage, experienceImage, selfImprovementImage;

    private void Start()
    {
        Change(10, 10, 10, 10);
    }

    public void Change(float academic, float network, float experience, float selfImprovement)
    {
        // akademik baþarý-network-experience-selfImprovement
        academicImage.fillAmount += (academic/100);
        networkImage.fillAmount += (network/100);
        experienceImage.fillAmount += (experience/100);
        selfImprovementImage.fillAmount += (selfImprovement/100);

        if ( academicImage.fillAmount == 0 ) UIManager.Instance.Lose(UIManager.LoseType.Academic);
        else if(networkImage.fillAmount  == 0) UIManager.Instance.Lose(UIManager.LoseType.Network);
        else if (experienceImage.fillAmount == 0) UIManager.Instance.Lose(UIManager.LoseType.Experience);
        else if (selfImprovementImage.fillAmount == 0) UIManager.Instance.Lose(UIManager.LoseType.SelfImprovement);
    }

    public void FinalCalculation()
    {
        // Katsayýlarý tekrar yüzlük sisteme döndür
        // Tüm sayýlarý kendi katsayýsý ile çarp, hepsini topla,
        // toplam katsayý puanýna böl, 70 baþarý puanýndan yüksekse KAZANDIK, aksi takdirde KAYBETTÝK

        float finalGrade;
        float academic, network, experience, selfImprovement;
        
        academic = academicImage.fillAmount * 100;
        network = networkImage.fillAmount * 100;
        experience = experienceImage.fillAmount * 100;
        selfImprovement = selfImprovementImage.fillAmount * 100;

        finalGrade = (academic * 5) + (network * 2) + (experience * 2) + (selfImprovement * 3);
        finalGrade = finalGrade / 12;

        if(finalGrade>70)
        {
            // Win
        }

        else
        {
            // Lose
        }
    }





}
