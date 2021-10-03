using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        Application.targetFrameRate = 60;
    }
    public void Start()
    {
       

    }
    public void PlayGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
