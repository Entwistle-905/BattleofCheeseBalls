using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float health = 100.0f;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        CheckDead();
    }

    private void CheckDead()
    {
        if (health < 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }

}
