using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelLoader : MonoBehaviour
{
    public Animator transition;
    public float TransitionTime=1f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TimeUnstuck()
    {
        Time.timeScale = 1;
    }

    public void LoadPinkGuy()
    {

        StartCoroutine (LoadPinkGuy(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator LoadPinkGuy (int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(2);

    }
    public void Reload()
    {

        StartCoroutine(reloadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator reloadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Loadinfi()
    {

        StartCoroutine (LoadInfinite(SceneManager.GetActiveScene().buildIndex));
       
    }

   public IEnumerator LoadInfinite(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(levelIndex);

    }

    public void MainMenu()
    {
        
        StartCoroutine(Menu(0));
    }
    IEnumerator Menu(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(levelIndex);

    }
}
