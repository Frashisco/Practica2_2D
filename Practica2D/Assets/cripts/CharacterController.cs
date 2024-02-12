using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChareacterController : MonoBehaviour
{
    public float speed;
    float inputMovement;
    Rigidbody2D rigidBody2D;
    public bool isLookingRight;
    public float jumpSpeed = 10;

    //Arregle Jump
    BoxCollider2D boxCollider;
    public bool isOnFloor;
    public LayerMask surfaceLayer;

    //Transition Animations
    public bool isRunning;
    private Animator animator;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessingMovement();
        isOnFloor = ChekingFloor();
        ProcessingJump();
    }

    //Función para las fuerzas
    public void ProcessingMovement()
    {
        inputMovement = Input.GetAxis("Horizontal");
        isRunning = inputMovement != 0 ? true : false;
        animator.SetBool("isRunning", isRunning);
        rigidBody2D.velocity = new Vector2(speed * inputMovement, rigidBody2D.velocity.y);
        CharacterHOrientation(inputMovement);
    }

    public bool ChekingFloor()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
                                    boxCollider.bounds.center, //Origen de la caja
                                    new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), //Tamaño, por defecto 1
                                    0f, //Ángulo
                                    Vector2.down, //Direccion hacia la que va la caja
                                    0.2f, //Distancia a la que aparece la caja
                                    surfaceLayer//Layer mask
                                    );

        return raycastHit.collider != null;
    }

    private void ProcessingJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
        {
            rigidBody2D.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void CharacterHOrientation(float inputMovement)
    {
        if ((isLookingRight && inputMovement < 0) || (!isLookingRight && inputMovement > 0))
        {
            isLookingRight = !isLookingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }
}