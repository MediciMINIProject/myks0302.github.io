using UnityEngine;

public class Gun : MonoBehaviour
{
    #region 주무기 관련
    public enum GunType { HG, SMG, AR };
    GunType gunType; //주무기 종류

    // 능력치
    int damage; //위력
    int magSize; //장탄수
    float push_Pow; //저지력

    bool isReload; //재장전 여부
    #endregion

    #region //부무기 관련
    public enum SubType { SG, SR, GL };
    SubType subType; //부무기 종류

    public Sub_SG Sub_SG;
    public Sub_SR Sub_SR;
    public Sub_GL Sub_GL;

    bool canShoot; //발사가능 여부

    int maxStock = 3; //최대 스톡
    int nowStock; //현재 스톡

    float coolDown; //장비 쿨타임

    float chargeTime; //스톡 충전 시간
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
                break;
            case SubType.SR:
                break;
            case SubType.GL:
                break;
        }
    }

    void MainShoot() 
    {

    }

    void SubShoot() 
    {

    }
    
    // Update is called once per frame
    void Update()
    {

    }


}
