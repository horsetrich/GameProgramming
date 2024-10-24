using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    [Header("Shop UI")]
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject[] choices;

    private const int maxAmount = 4;

    private static ShopManager instance;

    public bool shopping {  get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("too many shops found");
        }
        instance = this;
    }

    public static ShopManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        shopPanel.SetActive(false);
        shopping = false;
    }

    public void EnterShopMode()
    {
        shopPanel.SetActive(true);
        shopping = true;
        StartCoroutine(SelectFirstChoice());
    }

    public void ExitShopMode()
    {
        shopPanel.SetActive(false);
        shopping = false;
    }

    public void BuyDamage()
    {
        if(GameManager.GetInstance().numberDamageBought < maxAmount && GameManager.GetInstance().numberOfCoins >= 20)
        {
            GameManager.GetInstance().playerDamage++;
            GameManager.GetInstance().numberDamageBought++;
            GameManager.GetInstance().numberOfCoins = GameManager.GetInstance().numberOfCoins - 20;
        }
        else
        {
            return;
        }
    }

    public void BuySpeed()
    {
        if (GameManager.GetInstance().numberSpeedBought < maxAmount && GameManager.GetInstance().numberOfCoins >= 15)
        {
            GameManager.GetInstance().playerSpeed++;
            GameManager.GetInstance().numberSpeedBought++;
            GameManager.GetInstance().numberOfCoins = GameManager.GetInstance().numberOfCoins - 15;
        }
        else
        {
            return;
        }
    }

    public void BuyPotion()
    {
        if (GameManager.GetInstance().numberOfCoins >= 5)
        {
            GameManager.GetInstance().potions++;
            GameManager.GetInstance().numberOfCoins = GameManager.GetInstance().numberOfCoins - 5;
        }
        else
        {
            return;
        }
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

}
