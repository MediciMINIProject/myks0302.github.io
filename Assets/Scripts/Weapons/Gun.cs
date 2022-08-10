using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    #region �ֹ��� ����
    public enum GunType { HG, SMG, AR };
    public GunType gunType; //�ֹ��� ����

    // �ɷ�ġ
    int damage; //����

    int nowMag; //���� ���� źȯ
    int magSize; //��ź��
    float push_Pow; //������

    bool canShoot_M; //��� ���� ����
    #endregion

    #region //�ι��� ����
    public enum SubType { SG, SR, GL };
    SubType subType; //�ι��� ����

    public Sub_SG Sub_SG;
    public Sub_SR Sub_SR;
    public Sub_GL Sub_GL;

    bool canShoot_S; //�߻簡�� ����

    int maxStock = 3; //�ִ� ����
    int nowStock; //���� ����

    float coolDown; //��� ��Ÿ��

    float chargeTime; //���� ���� �ð�
    #endregion

    #region ����Ʈ ����

    public GameObject shootEffect; //�ѱ� ���

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        switch (gunType)
        {
            case GunType.HG:
                damage = 25;
                magSize = 8;
                push_Pow = 10.0f;
                break;
            case GunType.SMG:
                damage = 15;
                magSize = 25;
                push_Pow = 5.0f;
                break;
            case GunType.AR:
                damage = 20;
                magSize = 40;
                push_Pow = 7.5f;
                break;
        }

        switch (subType)
        {
            case SubType.SG:
                Sub_SG.SG_Shoot();
                break;
            
            case SubType.SR:
                Sub_SR.SR_Shoot();
                break;
            
            case SubType.GL:
                Sub_GL.GL_Shoot();
                break;
        }

        nowMag = magSize;
        nowStock = maxStock;

        canShoot_M = true;
        canShoot_S = true;
    }

    void MainShoot()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); //������ ����

        RaycastHit hitInfo; //�ε�ģ ��� Ȯ��

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.name.Contains("Enemy"))
            {
                Debug.Log("Hit!");

                /*
                // Enemy���� �� �� �¾Ҿ�
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                
                //�� ������
                enemy.TakeDamage(damage);

                //�� �з���
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                */

            }
        }
        
        nowMag--;

        if (nowMag <= 0) 
        {
            canShoot_M = false;
        }
    }

    void SubShoot()
    {
        switch (subType)
        {
            case SubType.SG:

                break;
            
            case SubType.SR:

                break;
            
            case SubType.GL:

                break;
        }

        if (nowStock <= 0)
        {
            canShoot_S = false;
        }
    }

    IEnumerator Reload() 
    {
        yield return new WaitForSeconds(3.0f);

        canShoot_M = true;
        nowMag = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && canShoot_M == true)
        {
            MainShoot();
        }
        
        if (OVRInput.GetDown(OVRInput.Button.One) && canShoot_S == true) 
        {
            SubShoot();
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            StartCoroutine(Reload());
        }
    }


}
