using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region 주무기 관련
    public enum GunType { HG, SMG, AR };
    public static GunType gunType; //주무기 종류

    // 능력치
    int damage; //위력

    int nowMag; //현재 남은 탄환
    int magSize; //장탄수
    float push_Pow; //저지력

    float reload_time; //재장전 시간

    bool canShoot_M; //사격 가능 여부
    #endregion

    #region //부무기 관련
    public enum SubType { SG, SR, GL };
    public static SubType subType; //부무기 종류

    public Sub_SG Sub_SG;
    public Sub_SR Sub_SR;
    public Sub_GL Sub_GL;

    bool canShoot_S; //발사가능 여부

    int maxStock = 3; //최대 스톡
    int nowStock; //현재 스톡

    float coolDown; //부장비 쿨타임
    #endregion

    #region 이펙트 관련

    public GameObject shootEffect; //총기 사격

    #endregion

    public Transform muzzle; //발사 위치

    public LineRenderer laser; //레이저 포인트

    //public WeaponUI.instance WeaponUI.instance; //무장 UI

    // Start is called before the first frame update
    void Start()
    {

        switch (gunType)
        {
            case GunType.HG:
                damage = 50;
                magSize = 8;
                push_Pow = 0.5f;
                reload_time = 1.5f;
                break;
            case GunType.SMG:
                damage = 15;
                magSize = 25;
                push_Pow = 0.2f;
                reload_time = 1.0f;
                break;
            case GunType.AR:
                damage = 25;
                magSize = 40;
                push_Pow = 0.3f;
                reload_time = 2.0f;
                break;
        }


        nowMag = magSize; //주무기 장탄수 채우기
        nowStock = maxStock; //부무기 장탄수 채우기

        canShoot_M = true;
        canShoot_S = true;



    }

    public void MainShoot()
    {
        //Ray ray = new(muzzle.position, muzzle.forward); //일직선 광선
        //Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.green);
        RaycastHit hitInfo; //부딧친 상대 확인

        if (Physics.Raycast(muzzle.position, muzzle.forward, out hitInfo, 30.0f, 1 << 8))
        {
            Debug.Log("Shoot");



            GameObject bi = Instantiate(shootEffect);
            bi.transform.position = hitInfo.point;
            bi.transform.forward = hitInfo.normal;

            ParticleSystem ps = bi.GetComponent<ParticleSystem>();
            ps.Stop();
            ps.Play();


            // Enemy에게 너 총 맞았어
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

            //적 데미지
            enemy.TakeDamage(damage);

            //적 밀려남
            enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * -push_Pow, ForceMode.Impulse);

        }

        nowMag--;
    }

    public void SubShoot()
    {
        switch (subType)
        {
            case SubType.SG:
                coolDown = 2;
                Sub_SG newSG = Instantiate(Sub_SG, muzzle.position, muzzle.rotation);
                newSG.SG_Shoot();
                break;

            case SubType.SR:
                coolDown = 1.5f;
                Sub_SR newSR = Instantiate(Sub_SR, muzzle.position, muzzle.rotation);
                newSR.SR_Shoot();
                break;

            case SubType.GL:
                coolDown = 3f;
               Sub_GL newGL = Instantiate(Sub_GL, muzzle.position, muzzle.rotation);
                newGL.GL_Shoot();
                break;
        }

    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(muzzle.position, muzzle.forward * 30.0f, Color.green);




        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && canShoot_M == true)
        {
            MainShoot();
            //WeaponUI.instance.main.text = nowMag + " / " + magSize;
        }

        if (OVRInput.GetDown(OVRInput.Button.One) && canShoot_S == true)
        {
            SubShoot();

        }

        if (OVRInput.GetDown(OVRInput.Button.Two) && nowMag != magSize)
        {
            StartCoroutine(Reload());
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

        laser.SetPosition(0, muzzle.position); //하나는 총구에

        Ray ray = new(muzzle.transform.position, muzzle.transform.forward); //일직선 광선
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo) && hitInfo.transform.CompareTag("Enemy"))
        {

            laser.SetPosition(1, hitInfo.transform.position); //나머지 하나는 그 적에게

        }
        else
        {
            laser.SetPosition(1, muzzle.position);
        }
    }
    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(reload_time);

        canShoot_M = true;
        nowMag = magSize;
    }


}
