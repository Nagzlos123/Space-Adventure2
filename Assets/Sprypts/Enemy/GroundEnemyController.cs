using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyController : MonoBehaviour
{
    [SerializeField] private float attachCooldown;
    [SerializeField] private float range;
    [SerializeField] private float coliderDis;
    [SerializeField] private int damage;

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private PlayerControler playerHealth;
    private PlayerControler playerArmor;
    private GroundEnemyPatrol patrolActive;

    private EnemyInventorySpawner spawnInventorySet;

    [SerializeField] private GameObject itemDrop;
    public bool isDead;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isDead = false;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //boxCollider = this.GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if(PlayerInSight())
        {
            if (cooldownTimer >= attachCooldown )
            {
                cooldownTimer = 0;
                animator.SetTrigger("Attack");
                
            }
            if(GetComponent<GroundEnemyPatrol>() != null)
            {
                GetComponent<GroundEnemyPatrol>().enabled = false;
            }
           
        }
        else
        {
            if (GetComponent<GroundEnemyPatrol>() != null)
            {
                GetComponent<GroundEnemyPatrol>().enabled = true;
            }
        }
        
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit2D = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * coliderDis,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left,0,playerLayer);
       
        if (hit2D.collider != null)
        {
            Debug.Log("Player is in sight!" + hit2D);
            playerHealth = hit2D.transform.GetComponent<PlayerControler>();
        }
            
        return hit2D.collider != null;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * coliderDis,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void TakeDamege(int damege)
    {
        currentHealth -= damege;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
       

        if (currentHealth <= 0)
        {
            //Instantiate(itemDrop, transform.position, Quaternion.identity);
            
            Die();
            
        }
    }

    void Die()
    {
        //spawnInventorySet.GetComponent<EnemyInventorySpawner>().RandomInventorySet();
       
        animator.SetBool("Death",true);
        isDead = true;
        //Destroy(gameObject);
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth.TakeDamege(damage);
        }
    }
}
