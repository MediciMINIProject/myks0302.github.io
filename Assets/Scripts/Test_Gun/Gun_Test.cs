using System.Collections;
using UnityEngine;

public class Gun_Test : MonoBehaviour
{
    public static Gun_Test instance;

    private void Awake()
    {
        Gun_Test.instance = this;
    }

    public enum GunType { HG, SMG, AR };
    public static GunType gunType; //주무기 종류  

    public enum SubType { SG, SR, GL };
    public static SubType subType; //부무기 종류

    public GameObject[] weaponPrefabs;

    public Transform[] muzzle; //총구
    Transform nowMuzzle; //나와야 하는 총구

    public Bullet bullet;//탄환

    public SG_Test SG_Test;
    public Sub_GL Sub_GL;
    public SR_Test SR_Test;

    int maxMag; //총기마다 설정된 기본 탄창
    int nowMag; //현재 남은 탄환 개수

    bool isReload;

    int maxStock;
    int nowStock;

    bool isDelay;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject prefab in weaponPrefabs) 
        {
            prefab.SetActive(false);
        }

        isReload = false;

        switch (gunType)
        {
            case GunType.HG:
                maxMag = 8;
                nowMuzzle = muzzle[0];
                weaponPrefabs[0].SetActive(true);
                break;
            
            case GunType.SMG:
                maxMag = 25;
                nowMuzzle = muzzle[1];
                weaponPrefabs[1].SetActive(true);
                break;
            
            case GunType.AR:
                maxMag = 40;
                nowMuzzle = muzzle[2];
                weaponPrefabs[2].SetActive(true);
                break;
        }

        WeaponUI.instance.MAIN_MAX = maxMag;
        WeaponUI.instance.SUB_MAX = maxStock;
        nowMag = maxMag;

        maxStock = 3;
        nowStock = maxStock;


        if (nowStock <= maxStock)
        {
            InvokeRepeating(nameof(Recharge), 0, 5);
        }

        
    }

    public void Shooting_M()
    {
        if (nowMag != 0)
        {
            Instantiate(bullet, nowMuzzle);
        }

        nowMag--;
    }

    public void Shooting_S()
    {
        if (nowStock > 0)
        {
            switch (subType)
            {
                case SubType.SG:
                    SG_Test newSG = Instantiate(SG_Test, nowMuzzle.position, nowMuzzle.rotation);
                    newSG.SG_Shoot();
                    break;
                case SubType.SR:
                    SR_Test newSR = Instantiate(SR_Test, nowMuzzle.position, nowMuzzle.rotation);
                    newSR.SR_Shoot();
                    break;
                case SubType.GL:
                    Sub_GL newGL = Instantiate(Sub_GL, nowMuzzle.position, nowMuzzle.rotation);
                    newGL.GL_Shoot();
                    break;
            }
        }

        nowStock--; 
    }

    // Update is called once per frame
    void Update()
    {
        

        if (GunController.instance.is_lefthands == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Shooting_M();

            }

            if (OVRInput.GetDown(OVRInput.Button.Three) && isDelay == false)
            {
                Shooting_S();
                StartCoroutine(Delay());
            }

            if (OVRInput.GetDown(OVRInput.Button.Four))
            {
                StartCoroutine(Reload());
            }
        }
        else 
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Shooting_M();

            }

            if (OVRInput.GetDown(OVRInput.Button.One) && isDelay == false)
            {
                Shooting_S();
                StartCoroutine(Delay());
            }

            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                StartCoroutine(Reload());
            }
        }


        if (nowMag < 0)
        {
            nowMag = 0;
        }

        if (isReload == true)
        {
            WeaponUI.instance.main.text = "Reload...";
        }

        

        if (nowStock > maxStock)
        {
            nowStock = maxStock;
        }

        WeaponUI.instance.MAIN_NOW = nowMag;
        WeaponUI.instance.SUB_NOW = nowStock;
    }

    public IEnumerator Reload()
    {
        isReload = true;

        yield return new WaitForSeconds(3.0f);

        isReload = false;
        nowMag = maxMag;
    }

    public IEnumerator Delay()
    {
        isDelay = true;

        yield return new WaitForSeconds(2.0f);

        isDelay = false;
    }

    public void Recharge()
    {
        nowStock += 1;
    }
}
