using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float runspeed = 3f;
     [SerializeField] float jumpspeed = 7f;
     [SerializeField] float climbSpeed = 6f;
     [SerializeField] float gravity = 9f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    SpriteRenderer spriteRenderer;
    Animator animator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFootCollider;
    public bool playerHasHorizontalSpeed = false;
    public bool playerisClimbing = false;
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        //footChecker - 
        myRigidbody.gravityScale = gravity;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFootCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()

    {
        playerSpeed = Mathf.Abs(myRigidbody.velocity.x);
        playerHasHorizontalSpeed = playerSpeed > Mathf.Epsilon;
        Run();
       if(playerisClimbing){ClimbLadder2();}
       // FlipSprite();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
        ActualFlipSprite();
    }

void ClimbLadder2(){
        //Debug.Log("Climbing");
        myRigidbody.gravityScale = 0;
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x,moveInput.y*climbSpeed);
        myRigidbody.velocity = climbVelocity;
        bool playerHasVerticalSpeed = Math.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        animator.SetBool("isClimbing",true);
        if(!playerHasVerticalSpeed){animator.speed = 0;} else {animator.speed = 1;}
        
    }

void EndClimbing(){
        playerisClimbing = false;
        myRigidbody.gravityScale = gravity;
        animator.speed = 1;
        animator.SetBool("isClimbing",false);
}

void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Ladder")){
            playerisClimbing = true;
        };
}

void OnTriggerExit2D(Collider2D other){
    if (other.gameObject.layer == LayerMask.NameToLayer("Ladder")){
      if(playerisClimbing){EndClimbing();};
    };
}




    void OnJump(InputValue value){
        string[] layernames = new string[] {"Ground","Ladder"};
        if(value.isPressed && myFootCollider.IsTouchingLayers(LayerMask.GetMask(layernames))){
        Debug.Log(myRigidbody.velocity.y);
        if(playerisClimbing){EndClimbing();};
        //if(value.isPressed && myRigidbody.velocity.y <= 0 ){
            myRigidbody.velocity += new Vector2(moveInput.x*runspeed,jumpspeed);
            //animator.SetBool("isJumping",true);
            //spriteRenderer.flipX = true;
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x*runspeed,myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        animator.SetBool("isRunning",playerHasHorizontalSpeed);       
}

void FlipSprite(){
    if (playerHasHorizontalSpeed){transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x),1f);}
}
void ActualFlipSprite(){
 if (moveInput.x < 0){
            spriteRenderer.flipX = true;
        } else if (moveInput.x > 0) {
            spriteRenderer.flipX = false;}
    }

}


