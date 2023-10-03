using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPlayerControler : MonoBehaviour
{
    float rotationZ;
    public Camera camera;
    public float moveSpeed = 5f;
    public Rigidbody2D rigidbody2D;
    Vector2 direction;
    Vector2 mousePos;
    public GameObject explosionGo;
    public int maxHealth = 600;
    public int currentHealth;
    public HealthBar healthBar;
    private GameObject[] gameObjects;
   
    
    void Start()
    {
        maxHealth = PlayerPrefs.GetInt("SpaceshipFullHP");
     
       
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        
    }



    // Update is called once per frame
    void Update()
    {
        
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        /*
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    TakeDamege(10);
                }
        */

        if (gameObjects.Length == 0)
        {
            Debug.Log("No game objects are tagged with 'Enemy'");
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider.gameObject);
    }
    void ProcessCollision(GameObject collider)
    {
        
        if (collider.CompareTag("Enemy") )
        {
            DoDamageToPlayer();
           
        }
        if ( collider.CompareTag("EnemyProjectile"))
        {
            DoDamageToPlayer();
            Destroy(collider.gameObject);
        }
        
    }

    void DoDamageToPlayer()
    {
        //Debug.Log("Hit!");

        TakeDamege(10);


        if (currentHealth == 0)
        {
            PlayExplosion();
            Destroy(gameObject);
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
    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + direction * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDirection = mousePos - rigidbody2D.position;
        // Mathf.Atan2 Zwraca kąt w radianach, którego Tan wynosi y/x.
        //Wartość zwracana to kąt między osią x a wektorem 2D, zaczynając od zera i kończąc na(x, y). 
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidbody2D.rotation = angle;
    }
}
