using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBetween : MonoBehaviour
{
    private GameObject Boss;
    private BossHealth bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.Find("BossSpirit");
        bossHealth = Boss.GetComponent<BossHealth>();

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
