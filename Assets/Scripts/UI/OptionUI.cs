using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
    public GameObject titleUI;

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void GotoTitle()
    {
        this.gameObject.SetActive(false);
        titleUI.SetActive(true);
    }
}
