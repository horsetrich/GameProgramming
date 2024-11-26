using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageBoundary : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(1);
            GameObject.Find("Player").GetComponent<Player>().transform.position = spawnPoint.transform.position;
        }
}
