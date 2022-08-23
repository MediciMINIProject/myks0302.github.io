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


    public Slider main_bar;
    public Slider sub_bar;

    public TextMeshProUGUI main_text;
    public TextMeshProUGUI sub_text;
}
