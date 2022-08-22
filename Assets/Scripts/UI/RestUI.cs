using UnityEngine;

public class RestUI : MonoBehaviour
{
    public static RestUI instance;

    public GunController gunController;

    private void Awake()
    {
        RestUI.instance = this;
    }

    public void NextWave() //버튼 이식
    {
        SpawnSystem.instance.wavecount++;
        
        //창 닫기
        gameObject.SetActive(false);

        //시간 흐르게 하기
        Time.timeScale = 1;

        gunController.enabled = true;

        StartCoroutine(SpawnSystem.instance.WaveSystem());
    }
}
