using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderNumber : MonoBehaviour
{
    public Text sliderNumber;
    public Slider slider;
    public void ChangeSliderValue()
    {
        sliderNumber.text = slider.value.ToString();
    }
}
