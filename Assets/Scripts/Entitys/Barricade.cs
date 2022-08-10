using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : HP
{
    public HP_UI HP_UI;

    // Start is called before the first frame update
    void Start()
    {
        STARTHP = 1000;

        HITPOINT = STARTHP;

        HP_UI.HPSlider.maxValue = STARTHP;
    }

    // Update is called once per frame
    void Update()
    {
        HP_UI.HPSlider.value = HITPOINT;
    }

}
