using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float speed = 4.0f;
    [SerializeField] float jumpForce = 10.5f;
    [SerializeField] private float attachCooldown;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject infoPanel1;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject portal;
    private GameObject KristalSpawner;
    //[SerializeField] private GameObject KristalSpawner2;

    private Animator animator;
    private Rigidbody2D rb2d;
    private float cooldownTimer = Mathf.Infinity;
    private Sensor groundCheck;
    private bool grounded = false;
    private bool combatIdle = false;
    private bool isDead = false;
    private bool xPressdKristalSpawner = false;
    private bool xPressdShop = false; 
    private bool xPressdPortal = false;



    public int maxHealth = 100;
    public int maxArmor = 50;
    public int attackDamage = 20;
    public int currentHealth;
    public int currentArmor;
    public HealthBar healthBar;
    public HealthBar armorBar;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    
    public int inventorySystemActive;
    private void Awake()
    {
        infoPanel.SetActive(false);
        infoPanel1.SetActive(false);
        portal.SetActive(false);
        inventoryPanel.SetActive(false);
        exitPanel.SetActive(false);
    }
    // Use this for initialization
    void Start()
    {
        maxHealth = PlayerPrefs.GetInt("PlayerFullHP");
        maxArmor = PlayerPrefs.GetInt("PlayerFullArmor");
        attackDamage = PlayerPrefs.GetInt("PlayerFullAttack");
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentArmor = maxArmor;
        armorBar.SetMaxArmor(maxArmor);
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck").GetComponent<Sensor>();

       
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Check if character just landed on the ground
        if (!grounded && groundCheck.State())
        {
            grounded = true;
            animator.SetBool("Grounded", grounded);
        }

        //Check if character just started falling
        if (grounded && !groundCheck.State())
        {
            grounded = false;
            animator.SetBool("Grounded", grounded);
        }


        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");


        // Swap direction of sprite depending on walk direction
        if (inputX < 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX > 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
        rb2d.velocity = new Vector2(inputX * speed, rb2d.velocity.y);

        //Set AirSpeed in animator
        animator.SetFloat("AirSpeed", rb2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e"))
        {
            if (!isDead)
                animator.SetTrigger("Death");
        }

        //Hurt
        else if (Input.GetKeyDown("q"))
            animator.SetTrigger("Hurt");

        //Attack
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (cooldownTimer >= attachCooldown)
            {
                cooldownTimer = 0;
                Attack();
            }

        }

        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            combatIdle = !combatIdle;

        //Jump
        else if (Input.GetKeyDown("space") && grounded)
        {


            animator.SetTrigger("Jump");
            grounded = false;
            animator.SetBool("Grounded", grounded);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            groundCheck.Disable(0.2f);
            //groundCheck.Disable(2f);

        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (combatIdle)
            animator.SetInteger("AnimState", 1);

        //Idle
        else
            animator.SetInteger("AnimState", 0);

        if (Input.GetKeyDown("x"))
        {
           if(xPressdKristalSpawner == true && infoPanel.activeSelf == true)
            {
                KristalSpawner.GetComponent<Collider2D>().GetComponent<KristalSpawnerControl>().SpawnEnemy();
                
            }

           if(xPressdShop == true && inventorySystemActive == 1)
            {
                //inventoryPanel.SetActive(true);
                exitPanel.SetActive(true);
            }
            else if(xPressdShop == true && inventorySystemActive != 1)
            {
                exitPanel.SetActive(true);
            }
        }
        
    }


    void Attack()
    {
       
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit!" + enemy.name);
            if (enemy.GetComponent<GroundEnemyController>() != null )
            {
                if(enemy.GetComponent<GroundEnemyController>().isDead == false)
                enemy.GetComponent<GroundEnemyController>().TakeDamege(attackDamage);

                if (enemy.GetComponent<GroundEnemyController>().isDead == true && inventorySystemActive == 1)
                {
                    enemy.GetComponent<EnemyInventorySpawner>().RandomInventorySet();
                }
                
               
            }

            if (enemy.GetComponent<ReactorControler>() != null)
            {
                enemy.GetComponent<ReactorControler>().TakeDamege(attackDamage);
            }

            if (enemy.GetComponent<BossP1Controler>() != null)
            {
                enemy.GetComponent<BossP1Controler>().TakeDamege(attackDamage);
            }
        }
    }
    public void TakeDamege(int damege)
    {
        if (currentArmor != 0 || currentArmor > 0)
        {
            currentArmor -= damege;
            armorBar.SetArmor(currentArmor);
        }
        else
        {
            currentHealth -= damege;
            healthBar.SetHealth(currentHealth);
        }

        if (currentArmor <= 0)
        {
            currentArmor = 0;
            currentHealth -= damege;
            healthBar.SetHealth(currentHealth);
        }




        if (currentHealth > 0 || currentArmor > 0)
        {
            animator.SetTrigger("Hurt");
        }
        else
        {
            if (!isDead)
                animator.SetTrigger("Death");

        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Death"))
        {

            if (currentArmor > 0)
            {
                TakeDamege(currentArmor);
                TakeDamege(currentHealth);
            }
            if (currentArmor == 0)
            {
                TakeDamege(currentHealth);
            }

            infoPanel.SetActive(true);

        }
    }

    private Collider2D OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("KristalSpawner"))
        {
            infoPanel.SetActive(true);

            xPressdKristalSpawner = true;
            KristalSpawner = collider.gameObject;
  
        }
     
        if (collider.CompareTag("Shop"))
        {
            infoPanel1.SetActive(true);

            xPressdShop = true;
            

        }
        return collider;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("KristalSpawner"))
        {
            infoPanel.SetActive(false);
            xPressdKristalSpawner = false;
        }

        if (collider.CompareTag("Shop"))
        {
            infoPanel1.SetActive(false);
            xPressdShop = false;
        }
    }
}


