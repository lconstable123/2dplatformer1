using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D rb;
    PlayerMovment player;
    float bulletDirection;
    EnemyMovement enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        player = FindObjectOfType<PlayerMovment>();
        CheckDirection();
        rb.velocity = new Vector3(bulletSpeed*bulletDirection, 0);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
 void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            //Debug.Log("bullet registered an enemy");
            enemy = other.gameObject.GetComponent<EnemyMovement>();
            enemy.Die();
        }
 }

    void CheckDirection(){
        if(!player.LR){bulletDirection = 1f;}else{bulletDirection = -1f;};
    }
}
