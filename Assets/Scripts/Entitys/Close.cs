using System.Collections;
using UnityEngine;

public class Close : Enemy
{
    public Animator closeAnimation; //�ൿ �ִϸ��̼�

    protected float distance; //�ڽŰ� Ÿ�ٰ��� �Ÿ�

    public HP_UI hp_ui;

    // Start is called before the first frame update
    void Start()
    {
        //ü�� ����
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

    IEnumerator Approach()
    {
        float refreshRate = 0.25f;

        while (target != null)
        {
            Vector3 targetposition = new Vector3(target.transform.position.x, 0, target.transform.position.z); //��ǥ ��ġ ���� ����

            mapAgent.SetDestination(targetposition); //��ǥ�� ��ġ�� ���� �̵�

            yield return new WaitForSeconds(refreshRate); //���� �ð����� �ʱ�ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {
        hp_ui.HPSlider.value = HITPOINT;
        
        distance = Vector3.Distance(target.transform.position, this.transform.position);


        if (isDead == false && mapAgent.remainingDistance <= (mapAgent.stoppingDistance + 0.5f))
        {
            closeAnimation.SetTrigger("Attack");//�ٰŸ� ����

        }
        else if (isDead == false && distance > (mapAgent.stoppingDistance + 0.5f))
        {
            //�̵�
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

            //������ �ٵ� �� AI �� Ȱ��ȭ
        }

        
    }
}
