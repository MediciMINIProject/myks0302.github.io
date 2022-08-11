using UnityEngine;

public class Sub_SG : MonoBehaviour
{
    #region ����Ʈ ����

    //public GameObject sgEffect; //�ѱ� ���

    public GameObject[] sgEffect;
    #endregion

    public Transform Bar_transform;

    int damage;
    float push_Pow;


    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        push_Pow = 5.0f;
    }

    public void SG_Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward); //������ ����

        RaycastHit hitInfo; //�ε�ģ ��� Ȯ��

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag("Enemy"))
            {
                float Dis_SG = Vector3.Distance(Bar_transform.position, hitInfo.transform.position); //�Ÿ� ���ϱ�

                // Enemy���� �� �� �¾Ҿ�
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                if (Dis_SG >= 30)
                {
                    enemy.TakeDamage(damage / 4);

                    //�� �з���
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 4, ForceMode.Impulse);
                }
                else if (Dis_SG < 30 && Dis_SG <= 20)
                {
                    enemy.TakeDamage(damage / 3);

                    //�� �з���
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 3, ForceMode.Impulse);
                }
                else if (Dis_SG < 20 && Dis_SG <= 10)
                {
                    enemy.TakeDamage(damage / 2);

                    //�� �з���
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 2, ForceMode.Impulse);
                }
                else if (Dis_SG < 10)
                {
                    enemy.TakeDamage(damage);

                    //�� �з���
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                }

                /*
                
                //�� ������
                enemy.TakeDamage(damage);

                //�� �з���
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                */

            }
            //GameObject SG_Effect = Instantiate(sgEffect, transform.position, transform.rotation);
            //Destroy(SG_Effect, 0.5f);


            foreach (GameObject pellets in sgEffect)
            {
                GameObject bi = Instantiate(pellets);
                
                bi.transform.position = hitInfo.point;

                bi.transform.forward = hitInfo.normal;

                ParticleSystem ps = bi.GetComponent<ParticleSystem>();
                ps.Stop();
                ps.Play();

            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

