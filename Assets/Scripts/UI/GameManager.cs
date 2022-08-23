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
        if (SpawnSystem.instance.REMAIN <= 0)
        {
            restUI.gameObject.SetActive(true);
            
            gunController.enabled = false;
            playUI.SetActive(false);

            //â
            HandedInputSelector.gameObject.SetActive(true);
        }

        if (Barricade.instance.HITPOINT <= 0)
        {
            playUI.SetActive(false);
            GameOverUI.instance.gameObject.SetActive(true);
            HandedInputSelector.gameObject.SetActive(true);
        }

        if (SpawnSystem.instance.WAVE == SpawnSystem.instance.mosterWaves.Length) 
        {
            playUI.SetActive(false);
            GameClearUI.gameObject.SetActive(true);
            restUI.gameObject.SetActive(false);
            HandedInputSelector.gameObject.SetActive(true);
        }

     
    }
}
