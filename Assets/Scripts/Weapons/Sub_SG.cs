using UnityEngine;

public class Sub_SG : MonoBehaviour
{
    #region ����Ʈ ����

    public GameObject sgEffect; //�ѱ� ���

    #endregion

    public Transform Bar_transform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SG_Shoot()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); //������ ����

        RaycastHit hitInfo; //�ε�ģ ��� Ȯ��

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.name.Contains("Enemy"))
            {
                Debug.Log("Hit!");

                float Dis_SG = Vector3.Distance(Bar_transform.position, hitInfo.transform.position); //�Ÿ� ���ϱ�
                
                // Enemy���� �� �� �¾Ҿ�
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                if (Dis_SG >= 30)
                {
                    Debug.Log("���� ���� ����");
                }
                else if (Dis_SG < 30 && Dis_SG <= 20)
                {
                    Debug.Log("���� ����");
                }
                else if (Dis_SG < 20 && Dis_SG <= 10)
                {
                    Debug.Log("���� ����");
                }
                else if (Dis_SG < 10)
                {
                    Debug.Log("���� ���� ����");
                }

                /*
                
                //�� ������
                enemy.TakeDamage(damage);

                //�� �з���
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                */

            }
            GameObject SG_Effect = Instantiate(sgEffect, transform.position, transform.rotation);
            Destroy(SG_Effect, 0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

