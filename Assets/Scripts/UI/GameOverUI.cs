using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;

    private void Awake()
    {
        GameOverUI.instance = this;
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exchange() 
    {
        SceneManager.LoadScene("SelectGear");
        Time.timeScale = 1;
    }

    public void Quit() 
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
    }
}
