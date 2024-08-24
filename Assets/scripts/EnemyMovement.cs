using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System;
using Unity.VisualScripting;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = -1f;
   
    bool flipCharacter = true;
    //Rigidbody2D myRigidBody;
    Rigidbody2D myRigidBody;
   // [SerializeField] BoxCollider2D floorCollider;
    SpriteRenderer myspriterender;
    //BoxCollider2D bodyProbe;

    // Start is called before the first frame update
    void Start()
    {
       // bodyProbe = GetComponent<BoxCollider2D>();
       // Transform bodyprobeGO = transform.Find("bodyprobe");
       // bodyProbe = bodyprobeGO.GetComponent<BoxCollider2D>();
        myspriterender = GetComponent<SpriteRenderer>();
        myRigidBody = GetComponent<Rigidbody2D>();
   
        
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = new Vector2(moveSpeed,0);
        myspriterender.flipX = flipCharacter;
    }
    

    public void FlipEnemy(){
       //Debug.Log("hit");
        moveSpeed = -moveSpeed;
        flipCharacter = !flipCharacter;
    }
    public void Die(){
        //Debug.Log("enemy registered a hit");
        Destroy(this.gameObject);
    }
   
    
}
