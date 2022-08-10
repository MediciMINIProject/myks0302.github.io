using System.Collections;
using UnityEngine;

public class Close : Enemy
{
    public Animator closeAnimation; //�ൿ �ִϸ��̼�

    protected float distance; //�ڽŰ� Ÿ�ٰ��� �Ÿ�

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

        if (isDead == true)
        {
            closeAnimation.SetTrigger("Death");

            Destroy(this.gameObject, 3f);
        }

       
    }
}
