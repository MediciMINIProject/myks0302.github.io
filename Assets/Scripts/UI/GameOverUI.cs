using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;


    private void Awake()
    {
        Time.timeScale = 1;
        GameOverUI.instance = this;
    }

    public void Restart() 
    {
        Time.timeScale = 1;

        SpawnSystem.instance.WAVE = 0;
        SpawnSystem.instance.Enemy_Total(SpawnSystem.instance.WAVE);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exchange() 
    {        
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("SelectGear");

    }

    public void Quit() 
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Title");

        
    }
}
