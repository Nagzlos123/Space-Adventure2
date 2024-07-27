using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase 
{
    public float moveSpeed;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    

    public GameObject explosionGo;
    public GameObject kredytDrop;
    public virtual void EnemyPattern()
    {

    }

 

    void TakeDamege(int damege)
    {
        currentHealth -= damege;
        healthBar.SetHealth(currentHealth);
    }


}
