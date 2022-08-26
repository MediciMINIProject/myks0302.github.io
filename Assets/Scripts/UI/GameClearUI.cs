using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{
    public static GameClearUI instance;

    public GunController gunController;
    private void Awake()
    {
        Time.timeScale = 1;
        GameClearUI.instance = this;
    }

    public void Restart()
    {
        SpawnSystem.instance.WAVE = 0;
        SpawnSystem.instance.Count_Reset();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Exchange()
    {
        gunController.enabled = false;
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("SelectGear");
    }

    public void Quit()
    {
        gunController.enabled = false;
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Title");
    }
}
