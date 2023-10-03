using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5f;
    //private Vector2 targetFirePoint1;
    //private Vector2 targetFirePoint2;
    //private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2D = this.GetComponent<Rigidbody2D>();
        //targetFirePoint1 = new Vector2(player.position.x, player.position.y);
       // targetFirePoint2 = new Vector2(player.position.x, player.position.y);
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {

            //Vector3 direction = player.position - transform.position;
            //float angleFirePoint = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rigidbody2D.rotation = angleFirePoint;

            //transform.position = Vector2.MoveTowards(transform.position, targetFirePoint1, moveSpeed * Time.deltaTime);
            //transform.position = Vector2.MoveTowards(transform.position, targetFirePoint2, moveSpeed * Time.deltaTime);
        }
        //Debug.Log(transform.position);
        /*
        if (transform.position.x == targetFirePoint2.x && transform.position.y == targetFirePoint2.y)
        {
            DestroyEnemyProjectile();
        }

        if (transform.position.x == targetFirePoint2.x && transform.position.y == targetFirePoint2.y)
        {
            DestroyEnemyProjectile();
        } */
        /*
        void OnTriggerEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player")) DestroyEnemyProjectile();
        }
       
        void DestroyEnemyProjectile()
            {
                Destroy(gameObject);
            }*/
        void OnTriggerEnter2D(Collider2D collider)
        {
            ProcessCollision(collider.gameObject);
        }
        void ProcessCollision(GameObject collider)
        {

            if (collider.CompareTag("Player") )
            {
                Destroy(collider.gameObject);
                
            }

            if (collider.CompareTag("Obstacle"))
            {
                Destroy(gameObject);

            }
        }
    }
}
