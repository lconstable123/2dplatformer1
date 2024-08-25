using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamesession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    ui ui;
    // Start is called before the first frame update
    void Awake(){
        
        int numGameSession = FindObjectsOfType<gamesession>().Length;
        if(numGameSession > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
            ui = FindObjectOfType<ui>();
        }
    }
    public void ProcessPlayerDeath(){
        if (playerLives > 1){
            TakeLife();
        } else {
            ResetGameSession();
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    void Start()
    {
        
    }
    void TakeLife(){
        Debug.Log("life taken");
        playerLives--;
        ui.updateScore();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getLives(){
        return playerLives;
    }
}
