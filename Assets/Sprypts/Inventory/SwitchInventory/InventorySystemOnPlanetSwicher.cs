using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemOnPlanetSwicher : MonoBehaviour
{
    [SerializeField] private GameObject playerHotBarPanel;
    [SerializeField] private GameObject equipmentPanel;
    [SerializeField] private GameObject mouseObject;
    //public List<GameObject> enemiesSpawned = new List<GameObject>();
    public GameObject[] enemiesSpawned;
    public int inventorySystemActive;
    public int activeEnemies;
    void Start()
    {
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");
        FindEnemies();
    }

    private void Update()
    {
        if(inventorySystemActive == 1)
        {
            playerHotBarPanel.SetActive(true);
            mouseObject.SetActive(true);
            FindEnemies();
            //RestoreItemDropFromEnemies();
        }

        if(inventorySystemActive != 1)
        {
            playerHotBarPanel.SetActive(false);
            mouseObject.SetActive(false);
            FindEnemies();
            RemoveItemDropFromEnemies();
        }

        
    }

    private void FindEnemies()
    {
        activeEnemies = GameObject.FindGameObjectsWithTag("GroundEnemy").Length;
        enemiesSpawned = GameObject.FindGameObjectsWithTag("GroundEnemy");
    }

    private void RemoveItemDropFromEnemies()
    {
        for (int enemy = 0; enemy < enemiesSpawned.Length; enemy++)
        {
            if (enemiesSpawned[enemy].GetComponent<EnemyInventorySpawner>() != null ) 
            {
                enemiesSpawned[enemy].GetComponent<EnemyInventorySpawner>().enabled = false;
                
            }

           
        }
    }

    private void RestoreItemDropFromEnemies()
    {
        for (int enemy = 0; enemy < enemiesSpawned.Length; enemy++)
        {
            if (enemiesSpawned[enemy].GetComponent<EnemyInventorySpawner>() != null)
            {
                enemiesSpawned[enemy].GetComponent<EnemyInventorySpawner>().enabled = true;

            }


        }
    }
}
