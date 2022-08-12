using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameClearUI GameClearUI;
    public GameOverUI GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        GameClearUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Barricade.instance.HITPOINT <= 0)
        {
            Time.timeScale = 0;
            GameOverUI.instance.gameObject.SetActive(true);
        }

    }
}
