using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.UI;

// Kan sette max hp
// kan sett faktisk hp


public class HealthBarTests
{
    private Slider _slider;
    private HealthBarController _healthBar;

    [SetUp]
    public void BeforeEveryTest()
    {
        _slider = new GameObject().AddComponent<Slider>();
        _healthBar = new HealthBarController(_slider);
    }
    // First test
    [Test]
    public void _0_setting_max_health_sets_slider_max_value()
    {
        _healthBar.SetMaxHealth(100.0f);

        Assert.AreEqual(100.0f, _slider.maxValue);
    }

    [Test]
    public void _1_setting_health_value_sets_slider_value()
    {
        _healthBar.SetMaxHealth(100.0f);
        _healthBar.SetValue(20.0f);

        Assert.AreEqual(20.0f, _slider.value);
    }
}
