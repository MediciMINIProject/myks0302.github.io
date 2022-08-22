using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{
    public static GameClearUI instance;

    private void Awake()
    {
        GameClearUI.instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exchange()
    {
        SceneManager.LoadScene("SelectGear");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Title");
    }
}
