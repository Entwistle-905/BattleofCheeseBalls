using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    float width;
    float rayCastLengthCheck = 0.3f;
    float Damage = 10.0f;
    void Start()
    {
        anim = GetComponent<Animator>();
        width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
    }

    void Update()
    {
        Punch();
    }

    private void Punch()
    {
        if (Input.GetButtonDown("Punch"))
        {
            // move animation
            anim.SetBool("IsPunch", true);
            RaycastHit2D HitInfo;

            if (HitInfo = Physics2D.Raycast(new Vector2(transform.position.x + width, transform.position.y), Vector2.right, rayCastLengthCheck))
            {
                Health OtherHealth = HitInfo.collider.gameObject.GetComponent<Health>();
                if (OtherHealth != null) 
                {
                    OtherHealth.TakeDamage(Damage);
                }
            }
        }
        else
        {
            anim.SetBool("IsPunch", false);
        }
    }
}
