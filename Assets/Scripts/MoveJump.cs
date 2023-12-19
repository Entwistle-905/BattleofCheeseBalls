using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Netcode;
//using UnityEditor.Animations;
using UnityEngine;

public class MoveJump : NetworkBehaviour
{
    float horizontal;
    public float speed = 10;
    public float jumpingPower = 10;
    //private bool isFacingRight = true;
    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;
    Collider2D[] Floor;
    Animator animator;
    public RuntimeAnimatorController[] controllers;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        GameObject[] Objects = GameObject.FindGameObjectsWithTag("Floor");
        Floor = new Collider2D[Objects.Length];

        for (int i = 0; i < Objects.Length; i++)
        {
            Floor[i] = Objects[i].GetComponent<Collider2D>();
        }

        
/*        if (NetworkManagerUI.IsServer == false)
        {
            animator.runtimeAnimatorController = controllers[1];
        }
        else if (NetworkManagerUI.IsServer == true)
        {
            animator.runtimeAnimatorController = controllers[0];
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (NetworkManagerUI.IsServer)
        {
            NetworkManager.Singleton.ConnectedClients[0].PlayerObject.GetComponent<Animator>().runtimeAnimatorController = controllers[0];
            if (NetworkManagerUI.IsClientExist == true)
            {
                NetworkManager.Singleton.ConnectedClients[1].PlayerObject.GetComponent<Animator>().runtimeAnimatorController = controllers[1];
            }
        }

        if (!IsOwner) return;
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Vertical") > 0.0f && IsTouchingGround())
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
            //spriteRenderer.flipX = false;   
            this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f) ;
        }
        else if (horizontal < 0f)
        {
            //spriteRenderer.flipX = true;
            this.transform.localScale = new Vector3(-1.1f, 1.1f, 1.1f);
        }
    }

    private bool IsTouchingGround()
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
