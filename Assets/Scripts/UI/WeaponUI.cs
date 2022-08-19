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

    int main_now;
    public int MAIN_NOW 
    {
        get { return main_now; }
        set
        {
            main_now = value;

        }
    }

    int main_max;
    public int MAIN_MAX 
    {
        get { return main_max; }
        set 
        {
            main_max = value;
            
        }
    }

    

    public TextMeshProUGUI sub; //何公厘
    
    int sub_now;
    public int SUB_NOW
    {
        get { return sub_now; }
        set
        {
            sub_now = value;
        }
    }
    int sub_max;
    public int SUB_MAX
    {
        get { return sub_max; }
        set
        {
            sub_max = value;
        }
    }

    private void Update()
    {
        WeaponUI.instance.main.text = MAIN_NOW +  " / " + MAIN_MAX;

        WeaponUI.instance.sub.text = SUB_NOW + " / " + SUB_MAX;
    }

}
