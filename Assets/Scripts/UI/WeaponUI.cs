using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    public static WeaponUI instance;

    private void Awake()
    {
        WeaponUI.instance = this;
    }

    public TextMeshProUGUI main; //林公厘

    int main_max;
    public int MAIN_MAX 
    {
        get { return main_max; }
        set 
        {
            main_max = value;
            //main.text = $"{main_max}/{main_max;
        }
    }

    

    public TextMeshProUGUI sub; //何公厘
    
    int sub_max;
    public int SUB_MAX
    {
        get { return sub_max; }
        set
        {
            sub_max = value;
        }
    }

    

    
}
