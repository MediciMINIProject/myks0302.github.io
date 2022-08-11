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
        hp_ui.HPSlider.maxValue = STARTHP;
    }

    IEnumerator Approach()
    {
        float refreshRate = 0.25f;

        while (target != null)
        {
            Vector3 targetposition = new(target.transform.position.x, 0, target.transform.position.z); //��ǥ ��ġ ���� ����

            mapAgent.SetDestination(targetposition); //��ǥ�� ��ġ�� ���� �̵�

            yield return new WaitForSeconds(refreshRate); //���� �ð����� �ʱ�ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, this.transform.position);

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

        if (isDead == true)
        {
            rangeAnimation.SetBool("Walk", false);

            //rangeAnimation.SetTrigger("Dead");

            Destroy(this.gameObject, 3f);
        }

        hp_ui.HPSlider.value = HITPOINT;
    }

}
