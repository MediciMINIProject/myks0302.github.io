using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region �ֹ��� ����
    public enum GunType { HG, SMG, AR };
    public static GunType gunType; //�ֹ��� ����

    // �ɷ�ġ
    int damage; //����

    int nowMag; //���� ���� źȯ
    int magSize; //��ź��
    float push_Pow; //������

    bool canShoot_M; //��� ���� ����
    #endregion

    #region //�ι��� ����
    public enum SubType { SG, SR, GL };
    public static SubType subType; //�ι��� ����

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

    public Transform muzzle; //�߻� ��ġ

    public LineRenderer laser; //������ ����Ʈ

    //public WeaponUI.instance WeaponUI.instance; //���� UI

    // Start is called before the first frame update
    void Start()
    {

        switch (gunType)
        {
            case GunType.HG:
                damage = 50;
                magSize = 8;
                push_Pow = 0.5f;
                break;
            case GunType.SMG:
                damage = 15;
                magSize = 25;
                push_Pow = 0.2f;
                break;
            case GunType.AR:
                damage = 25;
                magSize = 40;
                push_Pow = 0.3f;
                break;
        }


        nowMag = magSize; //�ֹ��� ��ź�� ä���
        nowStock = maxStock; //�ι��� ��ź�� ä���

        canShoot_M = true;
        canShoot_S = true;

        WeaponUI.instance.MAIN_MAX = magSize;
        WeaponUI.instance.SUB_MAX = maxStock;

        WeaponUI.instance.main.text = nowMag + " / " + magSize;
        WeaponUI.instance.sub.text = nowStock + " / " + maxStock;

    }

    public void MainShoot()
    {
        //Ray ray = new(muzzle.position, muzzle.forward); //������ ����
        //Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.green);
        RaycastHit hitInfo; //�ε�ģ ��� Ȯ��

        if (Physics.Raycast(muzzle.position, muzzle.forward, out hitInfo, 30.0f, 1 << 8))
        {
            Debug.Log("Shoot");
            return; //LJH


            GameObject bi = Instantiate(shootEffect);
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

        nowMag--;
    }

    public void SubShoot()
    {
        switch (subType)
        {
            case SubType.SG:
                Sub_SG newSG = Instantiate(Sub_SG, muzzle.position, muzzle.rotation);
                newSG.SG_Shoot();
                break;

            case SubType.SR:
                Sub_SR newSR = Instantiate(Sub_SR, muzzle.position, muzzle.rotation);
                newSR.SR_Shoot();
                break;

            case SubType.GL:
                Sub_GL newGL = Instantiate(Sub_GL, muzzle.position, muzzle.rotation);
                newGL.GL_Shoot();
                break;
        }

        nowStock--;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(muzzle.position, muzzle.forward * 30.0f, Color.green);


        if (GunController.instance.is_lefthands == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && canShoot_M == true)
            {
                MainShoot();
                WeaponUI.instance.main.text = nowMag + " / " + magSize;
            }

            if (OVRInput.GetDown(OVRInput.Button.Three) && canShoot_S == true)
            {
                SubShoot();
                WeaponUI.instance.sub.text = nowStock + " / " + maxStock;
            }

            if (OVRInput.GetDown(OVRInput.Button.Four) && nowMag != magSize)
            {
                StartCoroutine(Reload());
            }
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && canShoot_M == true)
            {
                MainShoot();
                WeaponUI.instance.main.text = nowMag + " / " + magSize;
            }

            if (OVRInput.GetDown(OVRInput.Button.One) && canShoot_S == true)
            {
                SubShoot();
                WeaponUI.instance.sub.text = nowStock + " / " + maxStock;
            }

            if (OVRInput.GetDown(OVRInput.Button.Two) && nowMag != magSize)
            {
                StartCoroutine(Reload());
            }
        }




        if (nowMag <= 0)
        {
            canShoot_M = false;
        }

        if (nowStock <= 0)
        {
            canShoot_S = false;
        }

        //StartCoroutine(Recharge());

        laser.SetPosition(0, muzzle.position); //�ϳ��� �ѱ���

        Ray ray = new(muzzle.transform.position, muzzle.transform.forward); //������ ����
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo) && hitInfo.transform.CompareTag("Enemy"))
        {

            laser.SetPosition(1, hitInfo.transform.position); //������ �ϳ��� �� ������

        }
        else
        {
            laser.SetPosition(1, muzzle.position);
        }
    }
    public IEnumerator Reload()
    {
        WeaponUI.instance.main.text = "Reload...";

        yield return new WaitForSeconds(3.0f);

        WeaponUI.instance.main.text = nowMag + " / " + magSize;

        canShoot_M = true;
        nowMag = magSize;
    }

    public IEnumerator Recharge()
    {
        if (nowStock != maxStock)
        {
            yield return new WaitForSeconds(3.0f);

            nowStock++;
           
            StartCoroutine(nameof(Recharge), 3.0f);
        }
        else
        {
            yield return new WaitForSeconds(0); //���� �Ҹ����� ����

            StartCoroutine(nameof(Recharge)); //������ ���� ���ϸ� ������ ���� ��� ����
        }
    }
}
