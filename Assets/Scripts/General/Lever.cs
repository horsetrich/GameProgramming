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

    [SerializeField] private BossHealth bossHealth;
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
        if (turnedOn)
        {
            TurnOff();
        }
        if (bossHealth.secondPhase)
        {
            Destroy(gameObject);
        }
    }

    public void FlipSwitch()
    {
        if (turnedOn)
        {
            animator.SetBool("On", true);

        }
        else if (!turnedOn)
        {
            animator.SetBool("On", false);
        }
    }
    public void MakeLight()
    {
        Instantiate(lightSource, source);
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
