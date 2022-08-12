using UnityEngine;

public class Sub_SG : MonoBehaviour
{
    #region ����Ʈ ����

    //public GameObject sgEffect; //�ѱ� ���

    public GameObject[] sgEffect;
    #endregion

    int damage;
    float push_Pow;

    public Transform muzzle;

    //źȯ ��Ʈ����
    Vector3 cluster;

    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        push_Pow = 5.0f;

        cluster = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
    }

    public void SG_Shoot()
    {
        Ray ray = new(muzzle.transform.position, muzzle.transform.forward); //������ ����

        RaycastHit hitInfo; //�ε�ģ ��� Ȯ��
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag("Enemy"))
            {
                GameObject bi = Instantiate(sgEffect[0]);
                bi.transform.position = hitInfo.point;

                bi.transform.forward = hitInfo.normal;

                ParticleSystem ps = bi.GetComponent<ParticleSystem>();
                ps.Stop();
                ps.Play();


                // Enemy���� �� �� �¾Ҿ�
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                //�� ������
                enemy.TakeDamage(damage);

                //�� �з���
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * -push_Pow, ForceMode.Impulse);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        

    }
}

