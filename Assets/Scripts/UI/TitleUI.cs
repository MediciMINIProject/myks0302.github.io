using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleUI : MonoBehaviour
{
    public GameObject optionUI;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        optionUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoSelect() 
    {
        SceneManager.LoadScene("SelectGear");
    }

    public void GotoOption() 
    {
        this.gameObject.SetActive(false);
        optionUI.SetActive(true);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
