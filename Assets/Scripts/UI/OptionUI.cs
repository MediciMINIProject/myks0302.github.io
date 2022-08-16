using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
    public GameObject titleUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandOptionR() 
    {
        GunController.instance.is_lefthands = false;
    }
    public void HandOptionL() 
    {
        GunController.instance.is_lefthands = true;
    }

    public void Title()
    {
        this.gameObject.SetActive(false);
        titleUI.SetActive(true);
    }
}
