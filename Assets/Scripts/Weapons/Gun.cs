using UnityEngine;

public class Gun : MonoBehaviour
{
    #region �ֹ��� ����
    public enum GunType { HG, SMG, AR };
    GunType gunType; //�ֹ��� ����

    // �ɷ�ġ
    int damage; //����
    int magSize; //��ź��
    float push_Pow; //������

    bool isReload; //������ ����
    #endregion

    #region //�ι��� ����
    public enum SubType { SG, SR, GL };
    SubType subType; //�ι��� ����

    public Sub_SG Sub_SG;
    public Sub_SR Sub_SR;
    public Sub_GL Sub_GL;

    bool canShoot; //�߻簡�� ����

    int maxStock = 3; //�ִ� ����
    int nowStock; //���� ����

    float coolDown; //��� ��Ÿ��

    float chargeTime; //���� ���� �ð�
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
