using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject projectile1;
    public float projectileForce = 2f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }

        void Shooting()
        {
            GameObject pro1 = Instantiate(projectile1, firePoint1.position, firePoint1.rotation);
            GameObject pro2 = Instantiate(projectile1, firePoint2.position, firePoint2.rotation);

            Rigidbody2D rb1 = pro1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = pro2.GetComponent<Rigidbody2D>();

            rb1.AddForce(firePoint1.up * projectileForce, ForceMode2D.Impulse);
            rb2.AddForce(firePoint2.up * projectileForce, ForceMode2D.Impulse);

        }
        
    }
}
