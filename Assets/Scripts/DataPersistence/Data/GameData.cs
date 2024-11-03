using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public int playerDamage;
    public float playerSpeed;
    public int amountOfJumps;
    public int numberOfCoins;
    public int potions;
    public string sceneName;


    public GameData()
    {
        playerPosition = Vector3.zero;
        playerDamage = 1;
        playerSpeed = 10f;
        amountOfJumps = 1;
        amountOfJumps = 1;
        numberOfCoins = 0;
        potions = 0;
        sceneName = "";
    }
}
