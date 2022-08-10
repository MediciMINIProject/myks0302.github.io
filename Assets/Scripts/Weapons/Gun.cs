using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    #region 주무기 관련
    public enum GunType { HG, SMG, AR };
    public GunType gunType; //주무기 종류

    // 능력치
    int damage; //위력

    int nowMag; //현재 남은 탄환
    int magSize; //장탄수
    float push_Pow; //저지력

    bool canShoot_M; //사격 가능 여부
    #endregion

    #region //부무기 관련
    public enum SubType { SG, SR, GL };
    public SubType subType; //부무기 종류

    public Sub_SG Sub_SG;
    public Sub_SR Sub_SR;
    public Sub_GL Sub_GL;

    bool canShoot_S; //발사가능 여부

    int maxStock = 3; //최대 스톡
    int nowStock; //현재 스톡

    float coolDown; //장비 쿨타임

    float chargeTime; //스톡 충전 시간
    #endregion

    #region 이펙트 관련

    public GameObject shootEffect; //총기 사격

    #endregion

    public Transform muzzle; //발사 위치

    public LineRenderer laser; //레이저 포인트

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

        nowMag = magSize; //주무기 장탄수 채우기
        nowStock = maxStock; //부무기 장탄수 채우기

        canShoot_M = true;
        canShoot_S = true;
    }

    public void MainShoot()
    {
        Ray ray = new Ray(muzzle.position, Camera.main.transform.forward); //일직선 광선

        RaycastHit hitInfo; //부딧친 상대 확인

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.name.Contains("Enemy"))
            {
                

                /*
                // Enemy에게 너 총 맞았어
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                
                //적 데미지
                enemy.TakeDamage(damage);

                //적 밀려남
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                */

            }
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
    }

    public IEnumerator Reload() 
    {
        Debug.Log("Reloading!");

        yield return new WaitForSeconds(3.0f);

        canShoot_M = true;
        nowMag = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && canShoot_M == true)
        {
            MainShoot();
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
    }


}
