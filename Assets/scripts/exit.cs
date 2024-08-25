using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
 void OnTriggerEnter2D(Collider2D other){
   
    StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel(){
        yield return new WaitForSeconds(.1f);
         var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScene = (currentSceneIndex+1)%2;
        SceneManager.LoadScene(nextScene);
        
    }
}
