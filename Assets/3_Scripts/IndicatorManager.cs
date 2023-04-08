using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : MonoBehaviour
{
    public Image academicImage, networkImage, experienceImage, selfImprovementImage;
    
    public int degisimDegeri;

    public void Change(int academic,int network, int experience,int selfImprovement)
    {
        // akademik ba�ar�-network-experience-selfImprovement
        academicImage.fillAmount += (academic/100);
        networkImage.fillAmount+= (network/100);
        experienceImage.fillAmount += (experience/100);
        selfImprovementImage.fillAmount += (selfImprovement/100);

        if( academicImage.fillAmount==0) UIManager.Instance.Lose(UIManager.LoseType.Academic);
        else if(networkImage.fillAmount == 0) UIManager.Instance.Lose(UIManager.LoseType.Network);
        else if (experienceImage.fillAmount == 0) UIManager.Instance.Lose(UIManager.LoseType.Experience);
        else if (selfImprovementImage.fillAmount == 0) UIManager.Instance.Lose(UIManager.LoseType.SelfImprovement);
    }

    // T�m say�lar� kendi katsay�s� ile �arp, hepsini topla,
    // toplam katsay� puan�na b�l, 70 ba�ar� puan�ndan y�ksekse KAZANDIK, aksi takdirde KAYBETT�K


    
}
