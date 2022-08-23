using System.Collections;
using UnityEngine;
using UnityEngine.AI; //NavAgent�� ����ϱ� ���� �غ�

public class Enemy : HP
{

    #region ���� AI
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
    }

    public IEnumerator Approach()
    {
        float refreshRate = 0.25f;

        while (Barricade.instance.transform != null)
        {
            Vector3 targetposition = new(Barricade.instance.transform.position.x, 0, Barricade.instance.transform.position.z); //��ǥ ��ġ ���� ����

            if (mapAgent.enabled == true)
            {
                mapAgent.SetDestination(targetposition); //��ǥ�� ��ġ�� ���� �̵�

            }


            yield return new WaitForSeconds(refreshRate); //���� �ð����� �ʱ�ȭ
        }
    }


    private void Update()
    {
    }
}

