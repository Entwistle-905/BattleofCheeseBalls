using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MoveJump : MonoBehaviour
{
    float horizontal;
    public float speed = 10;
    public float jumpingPower = 10;
    //private bool isFacingRight = true;
    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;
    public Collider2D[] Floor;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Debug.Log(rigid.velocity.y);

        if (Input.GetAxisRaw("Vertical") > 0.0f && IsTouchingGorund())
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpingPower);
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y);
    }


    private void Flip()
    {
        if (horizontal > 0f)
        {
            spriteRenderer.flipX = false;   
        }
        else if (horizontal < 0f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private bool IsTouchingGorund()
    {
        foreach(Collider2D Current in Floor)
        { 
            if (rigid.IsTouching(Current))
            {
                return true;
            }
        }
        return false;
    }
}
