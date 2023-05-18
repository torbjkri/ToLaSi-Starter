using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerHealthSO health_;

    private HealthBarController controller;
    private TextMeshProUGUI text_;
    // Start is called before the first frame update
    void Awake()
    {
        controller = new HealthBarController(gameObject.GetComponent<Slider>());
        controller.SetMaxHealth(health_.MaxHealth);
        text_ = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.SetValue(health_.Health);
        text_.text = string.Format("{0}/{1}", health_.Health, health_.MaxHealth);
    }
}
