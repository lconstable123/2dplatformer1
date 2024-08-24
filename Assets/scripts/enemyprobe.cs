using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyprobe : MonoBehaviour


{
EnemyMovement parentMovement;

 [SerializeField] bool isFeet;
 [SerializeField] bool isBody;
    void Start (){
        parentMovement = GetComponentInParent<EnemyMovement>();
    }
    // Start is called before the first frame update
   void OnTriggerExit2D(){
    if (isFeet){
    //Debug.Log("floor prober working");
     parentMovement.FlipEnemy();
    }
   }

   void OnTriggerEnter2D(){
    if (isBody){
    //Debug.Log("body prober working");
     parentMovement.FlipEnemy();
    }
   }




}
