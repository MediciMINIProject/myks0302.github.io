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
    
    
    
    
    public void NextWave() //버튼 이식
    {
        Time.timeScale = 1;

        SpawnSystem.instance.WAVE += 1;
        SpawnSystem.instance.Enemy_Total(SpawnSystem.instance.WAVE);

        SpawnSystem.instance.Count_Reset();
        SpawnSystem.instance.Total_Random();


        //Easy 난이도 : 각 라운드마다 체력 다시 초기화
        if (GameManager.level == GameManager.Level.Easy) 
        {
            Barricade.instance.HITPOINT = Barricade.instance.STARTHP;
        }

        int lost_hp; //잃어버린 체력
        //Normal 난이도 : 각 라운드 마다 잃어버린 체력 값의 0~100% 중 일부만 회복(10% 단위로 자름)
        if (GameManager.level == GameManager.Level.Normal)
        {
            lost_hp = Barricade.instance.STARTHP - Barricade.instance.HITPOINT;

            Barricade.instance.HITPOINT += (int)(lost_hp * System.Math.Round(Random.Range(0.0f, 1.0f), 1));
        }

        //Hard 난이도 : 체력 리젠 없음

        this.gameObject.SetActive(false);
        gameObject.SetActive(false);
        HandedInputSelector.gameObject.SetActive(false);

        gunController.enabled = true;
        playUI.SetActive(true);      
    }
}
