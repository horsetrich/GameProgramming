using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataPersistence
{

    private static GameManager instance;

    public int playerDamage = 1;
    public float playerSpeed = 10f;
    public int amountOfJumps = 1;
    public int numberOfCoins = 0;
    public int potions = 0;
    public int numberDamageBought = 0;
    public int numberSpeedBought = 0;
    public int numberJumpsBought = 0;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void LoadData(GameData data)
    {
        this.playerDamage = data.playerDamage;
        this.playerSpeed = data.playerSpeed;
        this.amountOfJumps = data.amountOfJumps;
        this.numberOfCoins = data.numberOfCoins;
        this.potions = data.potions;
    }
    public void SaveData(GameData data)
    {
        data.playerDamage = this.playerDamage;
        data.playerSpeed = this.playerSpeed;
        data.amountOfJumps = this.amountOfJumps;
        data.numberOfCoins = this.numberOfCoins;
        data.potions = this.potions;
    }
}
