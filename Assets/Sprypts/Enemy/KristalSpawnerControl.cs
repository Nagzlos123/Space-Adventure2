using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KristalSpawnerControl : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Transform[] spawnSpots;
    [SerializeField] private GameObject enemiesContainer;
    [SerializeField] private int maxNumberOfEnemies;
    [SerializeField] private float radius;
    private int randomSpot;
    private int numberOfEnemies;
    public List<GameObject> enemiesSpawned;
    public LayerMask enemyLayer;
    private GameObject newEnemyToSpawn;

    private void Start()
    {
        enemiesSpawned = new List<GameObject>();
       
            //OverlapAreaAll(spawnSpots[0].position, spawnSpots[])   


    }
    public void SpawnEnemy()
    {
        numberOfEnemies = Random.Range(1, maxNumberOfEnemies);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
        for (int i = 0; i < numberOfEnemies; i++)
        { 
            newEnemyToSpawn = (GameObject)Instantiate(enemyToSpawn, spawnSpots[i].position, Quaternion.identity);
            newEnemyToSpawn.transform.parent = enemiesContainer.transform;
            this.gameObject.SetActive(false);
            //enemiesSpawned.Add(newEnemyToSpawn);
            /*
            if (newEnemyToSpawn.transform.position == spawnSpots[randomSpot].position)
            {
                Debug.Log("Enemies are overlaping");
                enemiesSpawned.Remove(newEnemyToSpawn);
                Destroy(newEnemyToSpawn);
            }
            */
        }     
        

    }

    void OnDrawGizmosSelected()
    {
       
        //Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void RemoveFromList(GameObject enemy)
    {
        enemiesSpawned.Remove(enemy);
        
    }

}
