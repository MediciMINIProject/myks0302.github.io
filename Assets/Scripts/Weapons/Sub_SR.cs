using UnityEngine;

public class Sub_SR : MonoBehaviour
{
    #region ����Ʈ ����

    public GameObject srEffect; //�ѱ� ���

    #endregion

    public Transform Bar_transform;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SR_Shoot()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); //������ ����

        RaycastHit hitInfo; //�ε�ģ ��� Ȯ��

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.name.Contains("Enemy"))
            {
                Debug.Log("Hit!");

                float Dis_SR = Vector3.Distance(Bar_transform.position, hitInfo.transform.position); //�Ÿ� ���ϱ�

                //Enemy���� �� �� �¾Ҿ�
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                if (Dis_SR >= 30)
                {
                    Debug.Log("���� ���� ����");
                }
                else if (Dis_SR < 30 && Dis_SR <= 20)
                {
                    Debug.Log("���� ����");
                }
                else if (Dis_SR < 20 && Dis_SR <= 10)
                {
                    Debug.Log("���� ����");
                }
                else if (Dis_SR < 10)
                {
                    Debug.Log("���� ���� ����");
                }

                /*
                //
                
                //�� ������
                enemy.TakeDamage(damage);

                //�� �з���
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                */

            }
        }

        Instantiate(srEffect, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

