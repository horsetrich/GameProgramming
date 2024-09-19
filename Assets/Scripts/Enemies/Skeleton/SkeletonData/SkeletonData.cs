using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newSkeletonData", menuName = "Data/Skeleton Data/Base SkeletonData")]

public class SkeletonData : ScriptableObject
{
    [Header("Speed")]
    public float speed = 1.5f;

    [Header("Attack")]
    public int attack = 2;
    public LayerMask attackLayer;
    public float attackRange = 1.5f;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;
    public int numberOfAttacks = 0;
    public Vector3 attackOffset;

    [Header("Range")]
    public int range = 3;

    [Header("Dead State")]
    public float deadColliderHeight = 0.15f;
    public float upColliderHeight = 0.3f;

}
