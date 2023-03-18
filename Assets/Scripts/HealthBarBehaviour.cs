using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerHealthSO health_;

    private HealthBarController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = new HealthBarController(gameObject.GetComponent<Slider>());
        controller.SetMaxHealth(health_.MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        controller.SetValue(health_.Health);
    }
}
