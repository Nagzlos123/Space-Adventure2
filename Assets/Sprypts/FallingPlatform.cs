using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    //public float fallDelay = 2.0f;
    private Rigidbody2D rb;
    public bool respawn = true;
    Vector2 startPosition;
    public int timer = 0;
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>(); // Use awake as this is called before start.
    }

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
         
            rb.isKinematic = false;
            Debug.Log("Hit" + collision.gameObject.name);
            
           
            //StartCoroutine(FallAfterDelay());
        }
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider.gameObject);
    }
    void ProcessCollision(GameObject collider)
    {

        if (collider.CompareTag("Death")&& respawn)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector3 (0,0,0);
            transform.position = startPosition;
            //Destroy(gameObject);

        }
    }
    /*
    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
    }
    */
}
