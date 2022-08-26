using UnityEngine;

public class RestUI : MonoBehaviour
{
    public static RestUI instance;


    private void Awake()
    {
        RestUI.instance = this;
    }

    public GunController gunController;

    public GameObject playUI;

    public HandedInputSelector HandedInputSelector;
    
    
    
    
    public void NextWave() //��ư �̽�
    {
        Time.timeScale = 1;

        SpawnSystem.instance.WAVE += 1;
        SpawnSystem.instance.Enemy_Total(SpawnSystem.instance.WAVE);

        SpawnSystem.instance.Count_Reset();
        SpawnSystem.instance.Total_Random();


        //Easy ���̵� : �� ���帶�� ü�� �ٽ� �ʱ�ȭ
        if (GameManager.level == GameManager.Level.Easy) 
        {
            Barricade.instance.HITPOINT = Barricade.instance.STARTHP;
        }

        int lost_hp; //�Ҿ���� ü��
        //Normal ���̵� : �� ���� ���� �Ҿ���� ü�� ���� 0~100% �� �Ϻθ� ȸ��(10% ������ �ڸ�)
        if (GameManager.level == GameManager.Level.Normal)
        {
            lost_hp = Barricade.instance.STARTHP - Barricade.instance.HITPOINT;

            Barricade.instance.HITPOINT += (int)(lost_hp * System.Math.Round(Random.Range(0.0f, 1.0f), 1));
        }

        //Hard ���̵� : ü�� ���� ����

        this.gameObject.SetActive(false);
        gameObject.SetActive(false);
        HandedInputSelector.gameObject.SetActive(false);

        gunController.enabled = true;
        playUI.SetActive(true);      
    }
}
