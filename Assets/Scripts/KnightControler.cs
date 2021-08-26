using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightControler : MonoBehaviour
{
    //public properties
    public float velocityX = 10;
    public float JumpForce = 40;
    
    //private components
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;


    //Const, numeros del estado
    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_WALK = 1;
    private const int ANIMATION_RUN = 2;
    private const int ANIMATION_JUMP = 3;
    private const int ANIMATION_ATTACK = 4;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(ANIMATION_IDLE);

        //caminar derecha e izquierda
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;//cambio de lado en false
            changeAnimation(ANIMATION_WALK);
        }
        if(Input.GetKey(KeyCode.LeftArrow))//voltear de laso
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;//cambia de lado
            changeAnimation(ANIMATION_WALK);
        }

        //correr a la derecha e izquierda
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
        }
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
        }
        //Salto
        if(Input.GetKeyUp(KeyCode.Space) )
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            changeAnimation(ANIMATION_JUMP);
        }
        //Ataque
        if(Input.GetKeyUp(KeyCode.Z) )
        {
            changeAnimation(ANIMATION_ATTACK);
        }

    }
     private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);    
    }
}
