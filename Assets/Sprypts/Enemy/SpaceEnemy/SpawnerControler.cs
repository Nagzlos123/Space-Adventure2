using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerControler : MonoBehaviour
{
    public GameObject kredytDrop;
    public float timeBtwSpawn;
    public float statTime;
    public Transform spawnPoint;
    public GameObject[] enemyPrefabs;
    public GameObject explosionGo;
    public int maxHealth = 200;
    public int currentHealth;
    public HealthBar healthBar;
    public int playerAttackDamage = 5;
    public float spawnTime= 10f;
    public float spawnDelay= 5f;
    public  int enemies;
    public int maxEnemies = 4;
    private bool max;
    //public Button 

    // Start is called before the first frame update
    void Start()
    {
        playerAttackDamage = PlayerPrefs.GetInt("SpaceshipFullAttack");
        enemies = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        StartCoroutine(SpawnEnemy());
        //InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemies >= maxEnemies)
        {
            max = true;
        }

        if (enemies <= maxEnemies)
        {
            max = false;
        }
        /*
        if(enemies >= 4)
        {
            CancelInvoke("SpawnEnemy");
        }
        */


    }
    
    IEnumerator SpawnEnemy()
    {
        if (!max) //Only spawn when maximum isnt reaced
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randEnemy], spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(timeBtwSpawn);
            enemies++; // increase the enemy counter
            //timeBtwSpawn = statTime;
        }
        StartCoroutine(SpawnEnemy()); //Start the Coroutine again
    }
    
    /*
    private void SpawnEnemy()
    {
        
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randEnemy], spawnPoint.position, transform.rotation);
            enemies++;
            timeBtwSpawn = statTime;
       
    }
    */

    

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider.gameObject);
    }
    void ProcessCollision(GameObject collider)
    {

        if (collider.CompareTag("Projectile"))
        {
            Destroy(collider.gameObject);
            DoDamageToEnemy();

        }
    }

    void DoDamageToEnemy()
    {
        TakeDamege(playerAttackDamage);


        if (currentHealth <= 0)
        {
            PlayExplosion();
            Destroy(gameObject);
            Instantiate(kredytDrop, transform.position, Quaternion.identity);
        }

    }

    void TakeDamege(int damege)
    {
        currentHealth -= damege;
        healthBar.SetHealth(currentHealth);
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(explosionGo);

        explosion.transform.position = transform.position;
    }
}
