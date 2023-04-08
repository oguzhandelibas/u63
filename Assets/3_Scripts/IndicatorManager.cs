using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : MonoBehaviour
{
    public Image academicImage, networkImage, experienceImage, selfImprovementImage;
    
    public int degisimDegeri;
    // Start is called before the first frame update
    void Start()
    {
        
         
    }

    public void Change(int academic,int network, int experience,int selfImprovement)
    {
        // akademik baþarý-network-experience-selfImprovement
        academicImage.fillAmount += (academic/100);
        networkImage.fillAmount+= (network/100);
        experienceImage.fillAmount += (experience/100);
        selfImprovementImage.fillAmount += (selfImprovement/100);


        if( academicImage.fillAmount==0 || networkImage.fillAmount==0 || experienceImage.fillAmount==0 || selfImprovementImage.fillAmount==0 )
        {
            Debug.Log("lose");
        }
        //LoseControl();
        // UpdateIndicators();
    }


 
}
