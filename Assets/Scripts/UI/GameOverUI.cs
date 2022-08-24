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

        SpawnSystem.instance.NUM_CLOSE = SpawnSystem.instance.mosterWaves[SpawnSystem.instance.WAVE].num_close;
        SpawnSystem.instance.NUM_RANGE = SpawnSystem.instance.mosterWaves[SpawnSystem.instance.WAVE].num_range;
        SpawnSystem.instance.NUM_DRONE = SpawnSystem.instance.mosterWaves[SpawnSystem.instance.WAVE].num_drone;

        SpawnSystem.instance.REMAIN = SpawnSystem.instance.NUM_CLOSE + SpawnSystem.instance.NUM_RANGE + SpawnSystem.instance.NUM_DRONE;

        SpawnSystem.instance.StartCoroutine("WaveSystem");
        
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
