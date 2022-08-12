using System.Collections;
using UnityEngine;

public class Close : Enemy
{
    public Animator closeAnimation; //행동 애니메이션

    protected float distance; //자신과 타겟간의 거리

    public HP_UI hp_ui;

    // Start is called before the first frame update
    void Start()
    {
        //체력 배정
        switch (enemyRank)
        {
            case EnemyRank.Normal:
                STARTHP = 150;
                break;

            case EnemyRank.Cadre:
                STARTHP = 250;
                break;
        }

        this.HITPOINT = this.STARTHP;

        hp_ui.HPSlider.maxValue = STARTHP;

        StartCoroutine(Approach());

    }

   

    // Update is called once per frame
    void Update()
    {
        hp_ui.HPSlider.value = HITPOINT;
        
        distance = Vector3.Distance(Barricade.instance.transform.position, this.transform.position);


        if (isDead == false && distance <= (mapAgent.stoppingDistance + 0.5f))
        {
            closeAnimation.SetTrigger("Attack");//근거리 공격

        }
        else if (isDead == false && distance > (mapAgent.stoppingDistance + 0.5f))
        {
            //이동
            closeAnimation.SetTrigger("Move");
        }

        if (this.HITPOINT <= 0) 
        {
            isDead = true;
        }

        if (isDead == true)
        {
            closeAnimation.SetTrigger("Death");

            Destroy(this.gameObject, 3f);

            //리지드 바디 및 AI 비 활성화
        }

        
    }
}
