using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

public void UpdateHealthBar(int currentValue)
    {
        slider.value = currentValue;
    }

    // Update is called once per frame
    void Update()
    {

    }



}
