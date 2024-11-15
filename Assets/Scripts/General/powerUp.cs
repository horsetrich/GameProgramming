using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    // https://opengameart.org/content/magical-orbs-pack
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player") //if the player touches the powerup
        {
            GameManager.GetInstance().UpdateNumOfJumps();
            Destroy(this.gameObject); //destroy the powerup after it is picked up
        }
    }
}
