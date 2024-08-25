using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ui : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    gamesession gamesession;

  void Awake(){
        
        int numui = FindObjectsOfType<ui>().Length;
        if(numui > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
       gamesession = FindObjectOfType<gamesession>();
       updateScore();
    }
    public void updateScore()
    {
        score.text=gamesession.getLives().ToString();
    }
}
