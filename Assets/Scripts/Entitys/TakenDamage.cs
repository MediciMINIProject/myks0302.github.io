using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenDamage : HP
{
    public Barricade barricade;

    public override void TakeDamage(int i) 
    {
        barricade.TakeDamage(i);
    }
}
