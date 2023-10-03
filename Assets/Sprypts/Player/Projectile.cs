using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public GameObject hitEffect;
    /*
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag.Equals ("Projectile"))
        {
            Destroy(collision2D.gameObject);
            Destroy(gameObject);
        }

        if (collision2D.gameObject.tag.Equals("Opstacle"))
        {
            Destroy(collision2D.gameObject);
            Destroy(gameObject);
        }
        */

    void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider.gameObject);
    }
    void ProcessCollision(GameObject collider)
    {

        if (collider.CompareTag("Projectile"))
        {
            Destroy(collider.gameObject);

        }
        if (collider.CompareTag("Obstacle"))
        {
            
            Destroy(gameObject);

        }
    }
    //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //Destroy(effect);
    //Destroy(gameObject);
}

