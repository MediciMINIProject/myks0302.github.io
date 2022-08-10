using System.Collections;
using UnityEngine;
using UnityEngine.AI; //NavAgent�� ����ϱ� ���� �غ�

public class Enemy : HP
{
    #region ���� ����(��� ���� �ൿ���� ���)
    public enum EnemyRank { Normal, Cadre }; //���� ���
    public static EnemyRank enemyRank;
    #endregion

    #region ���� AI
    public GameObject target; //������ ���� ��ġ : �ٸ�����Ʈ

    public NavMeshAgent mapAgent; //AI �̽� �غ�
    #endregion

    #region ���� ����
    protected bool isDead; //��� ���� ����
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        isDead = false; //��� ���¸� false == �������

        mapAgent = GetComponent<NavMeshAgent>(); // �ڽſ��� �ִ� ������Ʈ ��������
        target = GameObject.FindGameObjectWithTag("Target"); //������Ʈ�� ��ġ ��������
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

    
    private void Update()
    {
        if (HITPOINT <= 0) 
        {
            isDead = true; //��� ���¸� true �� ����
        }      
    }
}

