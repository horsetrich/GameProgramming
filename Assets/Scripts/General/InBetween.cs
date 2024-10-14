using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBetween : MonoBehaviour
{
    public BossHealth bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PassAlong(int val)
    {
        bossHealth.GetHurt(val);
    }
}
