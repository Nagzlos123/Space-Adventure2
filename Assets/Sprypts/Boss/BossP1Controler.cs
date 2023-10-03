using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossP1Controler : MonoBehaviour
{
    [SerializeField] private float attachCooldown;
    [SerializeField] private float range;
    [SerializeField] private float coliderDis;
    [SerializeField] private int attackDamage1;
    [SerializeField] private int attackDamage2;

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject portal;
    [SerializeField] private Transform portalPos;
    private float cooldownTimer = Mathf.Infinity;
    private Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private PlayerControler playerHealth;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        Debug.Log("PlayerInSight() =" + PlayerInSight());
        if (PlayerInSight())
        {
            if (cooldownTimer >= attachCooldown)
            {
                Debug.Log("Player in sight!!");
                cooldownTimer = 0;
                animator.SetTrigger("Attack1");

            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit2D = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * coliderDis,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if (hit2D.collider != null)
        {
            Debug.Log("Player is in sight!" + hit2D);
            playerHealth = hit2D.transform.GetComponent<PlayerControler>();
        }
        else
        {
           // Debug.Log("Player isn't in sight!" + hit2D);
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
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("Death", true);
        InstantiatePortal();
        //Destroy(gameObject);
    }
    private void DamagePlayerAttack1()
    {
       
        if (PlayerInSight())
        {
            playerHealth.TakeDamege(attackDamage1);
        }
    }

    private void InstantiatePortal()
    {
        Instantiate(portal, portalPos.position, Quaternion.identity);
    }
}
