using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newSpiritData", menuName = "Data/Spirit Data/Base Spirit Data")]
public class SpiritData : ScriptableObject
{
    [Header("Spirit Speed")]
    public float spiritSpeed = 2f;
}
