using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataPersistenceManager.GetInstance().SaveGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Should save?");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Should save");
            DataPersistenceManager.GetInstance().SaveGame();
        }
    }
}
