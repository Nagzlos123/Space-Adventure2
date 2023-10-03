using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceEnemyControler : MonoBehaviour
{

    public GameObject kredytDrop;
    public GameObject projectile = null;
    public GameObject explosionGo;

    private Transform player;
    public Transform firePoint1 = null;
    public Transform firePoint2 = null;

    public float moveSpeed = 5f;
    public float stopDistance;
    public float retreatDistance;
   
    private Rigidbody2D rigidbody2D;
    public float statTime;
    private float timeBtwShots;

   
    public float projectileForce = 20f;
   
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int playerAttackDamage = 5;

    public bool enemy2 = false;

    private BoxCollider2D BoxColiderEnemy = null;

    // Start is called before the first frame update
    void Start()
    {
        BoxColiderEnemy = this.GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerAttackDamage = PlayerPrefs.GetInt("SpaceshipFullAttack");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if(enemy2)
            {
                EnemyPattern2();
            }
            else
            {
                EnemyPattern1();
            }
            
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    void EnemyPattern1()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rigidbody2D.rotation = angle;

        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        }
        else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
        }



        if (timeBtwShots <= 0)
        {

            GameObject pro1 = Instantiate(projectile, firePoint1.position, firePoint1.rotation);
            GameObject pro2 = Instantiate(projectile, firePoint2.position, firePoint2.rotation);

            Rigidbody2D rb1 = pro1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = pro2.GetComponent<Rigidbody2D>();

            rb1.AddForce(-firePoint1.up * projectileForce, ForceMode2D.Impulse);
            rb2.AddForce(-firePoint2.up * projectileForce, ForceMode2D.Impulse);

            //Instantiate(projectile2, transform.position, Quaternion.identity);
            timeBtwShots = statTime;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void EnemyPattern2()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rigidbody2D.rotation = angle;

        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
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

        if (collider.CompareTag("Player") && enemy2)
        {
            Destroy(gameObject);
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
