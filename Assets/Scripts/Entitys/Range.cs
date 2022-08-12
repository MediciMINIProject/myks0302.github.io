using System.Collections;
using UnityEngine;

public class Range : Enemy
{
    public Animator rangeAnimation; //행동 애니메이션

    protected float distance; //자신과 타겟간의 거리


    public HP_UI hp_ui;

    // Start is called before the first frame update
    void Start()
    {
        //체력 배정
        switch (enemyRank)
        {
            case EnemyRank.Normal:
                STARTHP = 100;
                break;

            case EnemyRank.Cadre:
                STARTHP = 150;
                break;
        }
        StartCoroutine(Approach());
        hp_ui.HPSlider.maxValue = STARTHP;
    }

    

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Barricade.instance.transform.position, this.transform.position);

        if (isDead == false && mapAgent.remainingDistance <= (mapAgent.stoppingDistance + 0.5f))
        {
            rangeAnimation.SetTrigger("Attack");
            //공격

            //데미지

        }
        else if (isDead == false && distance > (mapAgent.stoppingDistance + 0.5f))
        {
            rangeAnimation.SetBool("Walk", true);
            //추적
        }

        if (isDead == true)
        {
            rangeAnimation.SetBool("Walk", false);

            //rangeAnimation.SetTrigger("Dead");

            Destroy(this.gameObject, 3f);
        }

        hp_ui.HPSlider.value = HITPOINT;
    }

}
