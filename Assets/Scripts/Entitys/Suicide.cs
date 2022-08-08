using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : Enemy
{
    public GameObject suicideEffect;

    // Start is called before the first frame update
    void Start()
    {
        //체력 배정
        switch (enemyRank)
        {
            case EnemyRank.Normal:
                STARTHP = 50;
                break;

            case EnemyRank.Cadre:
                STARTHP = 100;
                break;
        }

        StartCoroutine("Approach");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false && mapAgent.remainingDistance <= (mapAgent.stoppingDistance + 0.5f))
        {
            print("부딧침");

            this.HITPOINT = 0;

            //this.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            GameObject exp = Instantiate(suicideEffect);
            exp.transform.position = this.transform.position;

            Destroy(this.gameObject);          
        }
    }




    
}
