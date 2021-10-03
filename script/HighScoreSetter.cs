using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScoreSetter : MonoBehaviour
{
    public string username;
    public TextMeshProUGUI TextField;
    public GameObject EnterButton;
    infiniteRunner player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StoreName()
    {
        username = TextField.text;
        Highscores.AddNewHighscore(username, PlayerPrefs.GetInt("HighScore", 1));

    }
}
