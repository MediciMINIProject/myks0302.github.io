using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameClearUI GameClearUI;
    public GameOverUI GameOverUI;
    public RestUI restUI;
    public GameObject playUI;

    public HandedInputSelector HandedInputSelector;

    public GunController gunController; 

    // Start is called before the first frame update
    void Start()
    {
        GameClearUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
        restUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Barricade.instance.HITPOINT <= 0)
        {
            Time.timeScale = 0;
            playUI.SetActive(false);
            GameOverUI.instance.gameObject.SetActive(true);
        }

        if (SpawnSystem.instance.wavecount == 9) 
        {
            playUI.SetActive(false);
            GameClearUI.gameObject.SetActive(true);
            restUI.gameObject.SetActive(false);
        }

        if (SpawnSystem.instance.waveremain == 0)
        {

            playUI.SetActive(false);

            //일시정지
            Time.timeScale = 0;

            //창
            restUI.gameObject.SetActive(true);
            HandedInputSelector.gameObject.SetActive(true);
        }

      
    }
}
