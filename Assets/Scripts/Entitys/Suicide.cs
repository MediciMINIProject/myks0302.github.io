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
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target")) 
        {
            collision.gameObject.GetComponent<HP>().TakeDamage(100); //바리케이트 체력 감소
            this.HITPOINT = 0;

            print("부딧침");

            //Destroy(this.gameObject);
        }
    }

    
}
