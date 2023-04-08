using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : MonoBehaviour
{
    public Slider sliderOne, sliderTwo, sliderThree, sliderFour;
    public int degisimDegeri;
    // Start is called before the first frame update
    void Start()
    {
         degisimDegeri = 10;
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


}
