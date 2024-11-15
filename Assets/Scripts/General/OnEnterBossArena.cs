using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class OnEnterBossArena : MonoBehaviour
{
    [SerializeField] private Light2D light;
    // [SerializeField] private float intensityValue = 1.3f; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        light.falloffIntensity = 0.3f;
    }
}
