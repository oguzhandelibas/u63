using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : MonoBehaviour
{
    public Slider[] deneme;
    public Slider sliderOne, sliderTwo, sliderThree, sliderFour;
    public int degisimDegeri;
    // Start is called before the first frame update
    void Start()
    {
        deneme = FindObjectsOfType<Slider>();
         degisimDegeri = 10;
    }

    public void Change(int academic,int network, int experience,int selfImprovement)
    {
        // akademik baþarý-network-experience-selfImprovement
        sliderOne.value += academic;
        sliderTwo.value += network;
        sliderThree.value += experience;
        sliderFour.value += selfImprovement;

        //LoseControl();
        // UpdateIndicators();
    }


    public void Arttirma()
    {

        sliderOne.value += degisimDegeri;
        sliderTwo.value += degisimDegeri;
        sliderThree.value -= degisimDegeri;
        sliderFour.value -= degisimDegeri;

    }

    public void Azaltma()
    {

        sliderOne.value -= degisimDegeri;
        sliderTwo.value -= degisimDegeri;
        sliderThree.value += degisimDegeri;
        sliderFour.value += degisimDegeri;
    }

    /*  public LoseControl()
      {
          foreach (var value in deneme)
          {
              if (value.value < 0)
                  return true;

          }  

          //if(FindObjectsOfType<Slider>
      } */
    // public UpdateIndicators()


}
