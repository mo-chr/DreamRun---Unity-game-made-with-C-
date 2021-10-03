using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    
    public bool gameHasEnded = false;

    public void gameOver()
    {
        if (gameHasEnded == false)
        {
            
            gameHasEnded = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

   
}
