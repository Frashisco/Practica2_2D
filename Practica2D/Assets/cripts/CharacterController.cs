using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChareacterController : MonoBehaviour
{
    public float speed;
    public float inputMovement;
    public bool isLookingRight;
    public float jumpSpeed;
    private Rigidbody2D rigidBody2D;

    //Arregle Jump
    BoxCollider2D boxCollider;
    public bool isOnFloor;
    public LayerMask surfaceLayer;
    public float JumpingMax;
    private float JumpingRestentes;

    //Transition Animations
    public bool isRunning;
    private Animator animator;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        JumpingRestentes = JumpingMax;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessingMovement();
        isOnFloor = ChekingFloor();
        ProcessingJump();
    }


    //Funci�n para las fuerzas
    void ProcessingMovement()
    {
        inputMovement = Input.GetAxis("Horizontal");
        isRunning = inputMovement != 0f ? true : false;
        animator.SetBool("isRunning", isRunning);
        rigidBody2D.velocity = new Vector2(speed * inputMovement, rigidBody2D.velocity.y);
        CharacterHOrientation(inputMovement);
    }

    bool ChekingFloor()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
                                    boxCollider.bounds.center, //Origen de la caja
                                    new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), //Tama�o, por defecto 1
                                    0f, //�ngulo
                                    Vector2.down, //Direccion hacia la que va la caja
                                    0.2f, //Distancia a la que aparece la caja
                                    surfaceLayer//Layer mask
                                    );

        return raycastHit.collider != null;
    }

    void ProcessingJump()
    {
        animator.SetBool("isJumping", !isOnFloor);
        if ( isOnFloor ) { JumpingRestentes = JumpingMax; }
        if (Input.GetKeyDown(KeyCode.Space) && JumpingRestentes > 0)
        {
            
            JumpingRestentes--;
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, 0f);
            rigidBody2D.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    void CharacterHOrientation(float inputMovement)
    {
        if ((isLookingRight && inputMovement < 0) || (!isLookingRight && inputMovement > 0))
        {
            isLookingRight = !isLookingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }
}