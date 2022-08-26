using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        GameManager.instance = this;
    }
    
    
    public GameClearUI GameClearUI;
    public GameOverUI GameOverUI;
    public RestUI restUI;
    public GameObject playUI;

    public HandedInputSelector HandedInputSelector;
    public GunController gunController;

    public enum Level { Easy, Normal,Hard }
    public static Level level = Level.Normal;

    // Start is called before the first frame update
    void Start()
    {
        gunController.enabled = true;
        GameClearUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
        restUI.gameObject.SetActive(false);
        HandedInputSelector.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((SpawnSystem.instance.REMAIN <= 0) && (SpawnSystem.instance.WAVE != SpawnSystem.instance.mosterWaves.Length - 1))
        {
            playUI.SetActive(false);
            gunController.enabled = false;
            
            restUI.gameObject.SetActive(true);
            HandedInputSelector.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
        else if ((SpawnSystem.instance.REMAIN <= 0) && (SpawnSystem.instance.WAVE == SpawnSystem.instance.mosterWaves.Length - 1)) 
        {
            playUI.SetActive(false);
            gunController.enabled = false;

            GameClearUI.gameObject.SetActive(true);           
            HandedInputSelector.gameObject.SetActive(true);

            Time.timeScale = 0;
        }

        if (Barricade.instance.HITPOINT <= 0)
        {
            playUI.SetActive(false);
            
            GameOverUI.instance.gameObject.SetActive(true);
            HandedInputSelector.gameObject.SetActive(true);

            Time.timeScale = 0;
        }   
    }
}
