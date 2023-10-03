using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    private int curentPatrolPoint = 0;
    
    [SerializeField] private Transform enemy;
    [SerializeField] private float moveSpeed;
    private float  waitTime;
    [SerializeField] private float startTime;
    private Vector3 inScale;
    private bool movingLeft;
    [SerializeField] private Animator animator;
    
    //public SpriteRenderer spriteRenderer;
    void Start()
    {
        waitTime = startTime;
        
        transform.position = patrolPoints[curentPatrolPoint].position;
        inScale = enemy.localScale;
    }

    private void Update()
    {
      
        Move();

        if (Vector2.Distance(transform.position, patrolPoints[curentPatrolPoint].position) < 0.01f)
        {
            if(waitTime <= 0)
            {
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            curentPatrolPoint++;
            if (curentPatrolPoint == patrolPoints.Length)
            {
                curentPatrolPoint = 0;
            }

        }
        /*
        if (!movingLeft)
        {
            if(enemy.position.x >= patrolPoints[0].position.x)
            {
                MoveInDirection(1);
                //enemy.localScale = new Vector3(1.0f,1.0f,1.0f);
            }
            else
            {
                ChangeDirection();
            }
            
        }
        else
        {
            if (enemy.position.x >= patrolPoints[1].position.x)
            {
                MoveInDirection(-1);
                
            }
            else
            {
                ChangeDirection();
            }
        }
        */

    }

    private void Move()
    {
        animator.SetBool("Run", true);
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[curentPatrolPoint].position, Time.deltaTime * moveSpeed);

       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Fllip1"))
        {
                
           MoveInDirection(-1);
             
        }

        if (collider.CompareTag("Fllip2"))
        {

            MoveInDirection(1);

        }

    }
    private void ChangeDirection()
    {
        animator.SetBool("Run", false);
        movingLeft = !movingLeft;
    }
    private void MoveInDirection(int direction)
    {
        animator.SetBool("Run", true);
        enemy.localScale = new Vector3(Mathf.Abs(inScale.x) * direction, inScale.y, inScale.z);
        //enemy.position = new Vector3(enemy.position.x * Time.deltaTime * direction * moveSpeed,enemy.position.y, enemy.position.z);
        
    }
}



