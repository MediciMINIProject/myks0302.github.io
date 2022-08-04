using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : HP
{

    // Start is called before the first frame update
    void Start()
    {
        STARTHP = 1000;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //근접 공격에 피격시

        //원거리 공격에 피격시

        //자폭 적에게 피격시
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
