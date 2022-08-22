using UnityEngine;

public class RestUI : MonoBehaviour
{
    public static RestUI instance;

    public GunController gunController;

    private void Awake()
    {
        RestUI.instance = this;
    }

    public void NextWave() //��ư �̽�
    {
        SpawnSystem.instance.wavecount++;
        
        //â �ݱ�
        gameObject.SetActive(false);

        //�ð� �帣�� �ϱ�
        Time.timeScale = 1;

        gunController.enabled = true;

        StartCoroutine(SpawnSystem.instance.WaveSystem());
    }
}
