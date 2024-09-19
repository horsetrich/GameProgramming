using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newGoblinData", menuName = "Data/Goblin Data/Base Goblin Data")]

public class GoblinData : ScriptableObject
{
    [Header("Attack Values")]
    public float range = 1.5f;
    public LayerMask attackMask;
    public Vector3 attackOffset;
    public int goblinDamage = 1;

    [Header("Goblin Eyes")]
    public float seeingDistance = 5f;

    [Header("Goblin Speed")]
    public float speed = 2f;
    public float fastSpeed = 4f;

    [Header("Goblin Health")]
    public int goblinMaxHealth = 8;
    public int goblinHealth = 0;

}
