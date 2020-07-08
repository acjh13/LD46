using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectionBar : MonoBehaviour
{
    public Slider slider;
    public float incrementValue;
    private float decrementValue;
    
    void Start()
    {
        decrementValue = slider.maxValue / 20.0f;
    }

    public float GetMaxLevel()
    {
        return slider.maxValue;
    }

    public float GetCurrentLevel()
    {
        return slider.value;
    }

    public bool CheckLoseCond()
    {
        return (slider.value >= slider.maxValue);
    }

    public void IncrementInfectionLevel()
    {
        slider.value += incrementValue;
    }

    public void DecrementInfectionLevel()
    {
        slider.value -= decrementValue;
    }
}
