using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamesession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    int initialLives;
    ui ui;
    // Start is called before the first frame update
    void Awake(){
        
        int numGameSession = FindObjectsOfType<gamesession>().Length;
        if(numGameSession > 1){
            Destroy(gameObject);
        }else{
            Debug.Log("setting up persistents");
            DontDestroyOnLoad(gameObject);
            ui = FindObjectOfType<ui>();
           ui.updateScore(playerLives);
            initialLives = playerLives;
        }
    }
    public void ProcessPlayerDeath(){
        if (playerLives > 1){
            TakeLife();
        } else {
            Debug.Log("resetting game session");
            ResetGameSession();
            
        }
    }

    private void ResetGameSession()
    {
        
        Debug.Log("Game Over");

       //playerLives = 3;
         // ui.updateScore();
       SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    void Start()
    {
        
    }
    void TakeLife(){
       
        playerLives--;
        ui.updateScore(playerLives);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getLives(){
        return playerLives;
    }
}
