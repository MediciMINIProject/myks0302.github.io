using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Enemy
{
    public Animator rangeAnimation; //�ൿ �ִϸ��̼�

    protected float distance; //�ڽŰ� Ÿ�ٰ��� �Ÿ�

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
    }

    IEnumerator Approach()
    {
        float refreshRate = 0.25f;

        while (target != null)
        {
            Vector3 targetposition = new Vector3(target.position.x, 0, target.position.z); //��ǥ ��ġ ���� ����

            mapAgent.SetDestination(targetposition); //��ǥ�� ��ġ�� ���� �̵�

            yield return new WaitForSeconds(refreshRate); //���� �ð����� �ʱ�ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, this.transform.position);

        if (isDead == false && distance <= mapAgent.stoppingDistance+1 )
        {
            rangeAnimation.SetTrigger("Attack");

            //����
        }
        else if (isDead == false && distance > mapAgent.stoppingDistance)
        {
            rangeAnimation.SetTrigger("Walk");
            //����
        }

        if (isDead == true)
        {
            //rangeAnimation.SetTrigger("Dead");

            Destroy(this.gameObject, 3f);
        }
    }
}
