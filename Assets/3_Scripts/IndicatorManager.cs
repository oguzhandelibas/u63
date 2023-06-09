using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : Singleton<IndicatorManager>
{
    public Image academicImage, networkImage, experienceImage, selfImprovementImage;
    [SerializeField] private GameObject[] indicatorCircles;

    private void Start()
    {
        Change(10, 10, 10, 10);
    }

    public void Change(float academic, float network, float experience, float selfImprovement)
    {
        // akademik ba�ar�-network-experience-selfImprovement
        academicImage.fillAmount += (academic/100);
        networkImage.fillAmount += (network/100);
        experienceImage.fillAmount += (experience/100);
        selfImprovementImage.fillAmount += (selfImprovement/100);

        if ( academicImage.fillAmount == 0 ) UIManager.Instance.Lose(UIManager.LoseType.Academic);
        else if(networkImage.fillAmount  == 0) UIManager.Instance.Lose(UIManager.LoseType.Network);
        else if (experienceImage.fillAmount == 0) UIManager.Instance.Lose(UIManager.LoseType.Experience);
        else if (selfImprovementImage.fillAmount == 0) UIManager.Instance.Lose(UIManager.LoseType.SelfImprovement);
    }

    public void IndicatorCircleActiveness(bool[] indicatorCircleActiveness = null)
    {
        if (indicatorCircleActiveness == null)
        {
            indicatorCircleActiveness = new bool[4];
            indicatorCircleActiveness[0] = false;
            indicatorCircleActiveness[1] = false;
            indicatorCircleActiveness[2] = false;
            indicatorCircleActiveness[3] = false;
        }
        indicatorCircles[0].SetActive(indicatorCircleActiveness[0]);
        indicatorCircles[1].SetActive(indicatorCircleActiveness[1]);
        indicatorCircles[2].SetActive(indicatorCircleActiveness[2]);
        indicatorCircles[3].SetActive(indicatorCircleActiveness[3]);
    }

    public float FinalCalculation()
    {
        // Katsay�lar� tekrar y�zl�k sisteme d�nd�r
        // T�m say�lar� kendi katsay�s� ile �arp, hepsini topla,
        // toplam katsay� puan�na b�l, 70 ba�ar� puan�ndan y�ksekse KAZANDIK, aksi takdirde KAYBETT�K

        float finalGrade;
        float academic, network, experience, selfImprovement;
        
        academic = academicImage.fillAmount * 100;
        network = networkImage.fillAmount * 100;
        experience = experienceImage.fillAmount * 100;
        selfImprovement = selfImprovementImage.fillAmount * 100;

        finalGrade = (academic * 5) + (network * 2) + (experience * 2) + (selfImprovement * 3);
        finalGrade = finalGrade / 12;

        return finalGrade;
    }

    public void _IndicatorActiveness(GameObject obj)
    {
        StartCoroutine(IndicatorActivenessRoutine(obj));
    }

    IEnumerator IndicatorActivenessRoutine(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(1);
        obj.SetActive(false);
    }



}
