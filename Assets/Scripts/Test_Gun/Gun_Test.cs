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

    public Transform muzzle; //총구

    public Bullet bullet;//탄환

    public SG_Test SG_Test;

    int maxMag;
    int nowMag;

    bool isReload;

    int maxStock;
    int nowStock;

    bool isDelay;

    // Start is called before the first frame update
    void Start()
    {
        isReload = false;

        switch (gunType)
        {
            case GunType.HG:
                maxMag = 8;
                break;
            case GunType.SMG:
                maxMag = 25;
                break;
            case GunType.AR:
                maxMag = 40;
                break;
        }

        nowMag = maxMag;

        maxStock = 3;
        nowStock = maxStock;

        WeaponUI.instance.MAIN_MAX = maxMag;
        WeaponUI.instance.SUB_MAX = maxStock;

        if (nowStock <= maxStock)
        {
            InvokeRepeating(nameof(Recharge), 0, 5);
        }
    }

    void Shooting_M()
    {
        if (nowMag != 0)
        {
            Instantiate(bullet, muzzle);
        }

        nowMag--;
    }

    void shooting_S()
    {
        if (nowStock > 0)
        {
            switch (subType)
            {
                case SubType.SG:
                    SG_Test newSG = Instantiate(SG_Test, muzzle.position, muzzle.rotation);
                    newSG.SG_Shoot();
                    break;
            }
        }

        nowStock--; 
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Shooting_M();

        }

        if (OVRInput.GetDown(OVRInput.Button.One) && isDelay == false)
        {
            shooting_S();
            StartCoroutine(Delay());
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            StartCoroutine(Reload());
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
