using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : Enemy
{
    public GameObject suicideEffect;

    // Start is called before the first frame update
    void Start()
    {
        //ü�� ����
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
            collision.gameObject.GetComponent<HP>().TakeDamage(100); //�ٸ�����Ʈ ü�� ����
            this.HITPOINT = 0;

            print("�ε�ħ");

            //Destroy(this.gameObject);
        }
    }

    
}
