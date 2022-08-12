using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenDamage : HP
{
    
    public override void TakeDamage(int i) 
    {
        Barricade.instance.TakeDamage(i);
    }
}
