using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSpiritBossData", menuName = "Data/SpiritBoss Data/SpiritBossBase Data")]

public class BossSpiritData : ScriptableObject
{
    [Header("Boss Attack")]
    public int bossDamage = 5;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;
    public int numberOfAttacks = 0;
    public LayerMask playerLayers;

    [Header("Misc")]
    public float canSee = 4f;
    public float speed = 4f;
}
