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

            this.HITPOINT = 0;

            GameObject exp = Instantiate(suicideEffect);
            exp.transform.position = this.transform.position;

            target.GetComponent<HP>().TakeDamage(100);
            
            Destroy(this.gameObject);
        }
    }




    
}
