using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField]
    private GameObject lightSource;
    [SerializeField]
    private Transform source;

    private Animator animator;

    public bool turnedOn = false;

    public void TurnOn() => turnedOn = true;

    public float counter = 0;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        counter += Time.deltaTime;
        FlipSwitch();
        TurnOff();
    }

    public void FlipSwitch()
    {
        if (turnedOn)
        {
            counter = 0;
            animator.SetBool("On", true);
            MakeLight();
            animator.SetBool("Off", false);

        }
        else if (!turnedOn)
        {
            animator.SetBool("On", false);
            animator.SetBool("Off", true);
        }
    }
    public void MakeLight()
    {
        Instantiate(lightSource, source, true);
        Destroy(lightSource, 5f);
    }

    public void TurnOff()
    {
        if(counter > 5)
        {
            turnedOn = false;
            counter = 0;
        }
    }
}
