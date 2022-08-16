using System.Collections;
using UnityEngine;

public class Range : Enemy
{
    public Animator rangeAnimation; //�ൿ �ִϸ��̼�

    protected float distance; //�ڽŰ� Ÿ�ٰ��� �Ÿ�


    public HP_UI hp_ui;

    // Start is called before the first frame update
    void Start()
    {
        //ü�� ����
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

        this.HITPOINT = this.STARTHP;

        hp_ui.HPSlider.maxValue = STARTHP;
    }

    

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Barricade.instance.transform.position, this.transform.position);
        
        hp_ui.HPSlider.value = HITPOINT;

        if (isDead == false && mapAgent.remainingDistance <= (mapAgent.stoppingDistance + 0.5f))
        {
            rangeAnimation.SetTrigger("Attack");
            //����

            //������

        }
        else if (isDead == false && distance > (mapAgent.stoppingDistance + 0.5f))
        {
            rangeAnimation.SetBool("Walk", true);
            //����
        }

        if (this.HITPOINT <= 0)
        {
            isDead = true;
        }

        if (isDead == true)
        {
            rangeAnimation.SetTrigger("Dead");

            Destroy(this.gameObject, 3f);

            //������ �ٵ� �� AI �� Ȱ��ȭ
        }
    }

}
