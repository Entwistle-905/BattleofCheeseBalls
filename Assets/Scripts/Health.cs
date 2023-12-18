using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
    float health = 100.0f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        CheckDead();
    }

    private void CheckDead()
    {
        if (health == 0 || health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        int death = Random.Range(0, 10);
        anim.SetInteger("DeadVer", death);
        anim.SetBool("IsDead", true);
    }

}
