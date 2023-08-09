using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    // Update is called once per frame

   
    void Update()
    {

    }

    public void UpdateHealthBarEnemy(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
