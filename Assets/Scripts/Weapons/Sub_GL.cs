using UnityEngine;

public class Sub_GL : MonoBehaviour
{
    #region ����Ʈ ����

    public GameObject glEffect; //�ѱ� ���

    #endregion

    float radius = 5.0f; //���� �ݰ�
    int damage = 75; //�ִ� ����



    // Start is called before the first frame update
    void Start()
    {

    }

    public void GL_Shoot() //�߻� ��Ŀ����
    {
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 40.0f, ForceMode.Impulse);
    }

    void Explode() //���� ��Ŀ����
    {
        Collider[] enemys = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearenemy in enemys)
        {
            Enemy enemy = nearenemy.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(glEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
