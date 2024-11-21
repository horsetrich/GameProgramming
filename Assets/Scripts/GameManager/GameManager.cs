using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour, IDataPersistence
{

    public static GameManager instance;

    public int playerDamage = 1;
    public float playerSpeed = 10f;
    public int amountOfJumps = 1;
    public int numberOfCoins = 0;
    public int potions = 0;
    public int numberDamageBought = 0;
    public int numberSpeedBought = 0;
    public int numberJumpsBought = 0;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI potionText;

    
    public PlayerData data = null;

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
        GameManager.GetInstance().UpdateUIText();
    }
    public void SaveData(GameData data)
    {
        data.playerDamage = this.playerDamage;
        data.playerSpeed = this.playerSpeed;
        data.amountOfJumps = this.amountOfJumps;
        data.numberOfCoins = this.numberOfCoins;
        data.potions = this.potions;
    }

    public void UpdateUIText()
    {
        if(coinText == null || potionText ==null)
        {
            return;
        }
        else
        {
            coinText.text = "X " + numberOfCoins;
            potionText.text = "X "+potions;
        }
    }    
    
    public void UpdateNumOfJumps()
    {
        data.amountOfJumps+=1; //gives an extra jump
    }
    public void AssignObjects()
    {
        data = GameObject.Find("Player").GetComponent<Player>().playerData; //finds a player in scene and applies its game playerData to data for changing
        coinText = GameObject.Find("coin").GetComponent<TextMeshProUGUI>();
        potionText = GameObject.Find("potionUI").GetComponent<TextMeshProUGUI>();
        
    }
}
