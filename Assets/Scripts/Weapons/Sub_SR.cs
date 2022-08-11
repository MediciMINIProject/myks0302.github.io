using UnityEngine;

public class Sub_SR : MonoBehaviour
{
    #region ����Ʈ ����

    public GameObject srEffect; //�ѱ� ���

    #endregion

    public Transform Bar_transform;

    int damage;
    float push_Pow;

    public Transform muzzle; //�߻� ��ġ

    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        push_Pow = 5.0f;
    }


    public void SR_Shoot()
    {
        Ray ray = new Ray(muzzle.transform.position, muzzle.transform.transform.forward); //������ ����

        RaycastHit hitInfo; //�ε�ģ ��� Ȯ��

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag("Enemy"))
            {
                Debug.Log("Hit!");

                float Dis_SR = Vector3.Distance(Bar_transform.position, hitInfo.transform.position); //�Ÿ� ���ϱ�

                //Enemy���� �� �� �¾Ҿ�
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                if (Dis_SR >= 30)
                {
                    enemy.TakeDamage(damage);

                    //�� �з���
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                }
                else if (Dis_SR < 30 && Dis_SR <= 20)
                {
                    enemy.TakeDamage(damage / 2);

                    //�� �з���
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 2, ForceMode.Impulse);
                }
                else if (Dis_SR < 20 && Dis_SR <= 10)
                {
                    enemy.TakeDamage(damage / 3);

                    //�� �з���
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 3, ForceMode.Impulse);
                }
                else if (Dis_SR < 10)
                {
                    enemy.TakeDamage(damage / 4);

                    //�� �з���
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 4, ForceMode.Impulse);
                }

                /*
                //
                
                //�� ������
                enemy.TakeDamage(damage);

                //�� �з���
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                */

                GameObject bi = Instantiate(srEffect);
                bi.transform.position = hitInfo.point;

                bi.transform.forward = hitInfo.normal;

                ParticleSystem ps = bi.GetComponent<ParticleSystem>();
                ps.Stop();
                ps.Play();

            }
        }

        Instantiate(srEffect, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

