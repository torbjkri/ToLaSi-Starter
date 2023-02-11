using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController
{
    private Slider slider;
    public HealthBarController(Slider slider_)
    {
        slider = slider_;
    }

    public void SetMaxHealth(float new_max)
    {
        slider.maxValue = new_max;
    }

    public void SetValue(float new_value)
    {
        slider.value = new_value;
    }

}
