using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int maxValue;
    public int minValue;

    public int value;

    public void Start()
    {
        value = Random.Range(minValue, maxValue); //make a random number between given values
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player") //if the player touches the coin
        {
            GameManager.GetInstance().numberOfCoins = GameManager.GetInstance().numberOfCoins + value; //give money
            GameManager.GetInstance().UpdateCoinText();
            Destroy(this.gameObject); //destroy the coin after it is picked up
        }
    }
}
