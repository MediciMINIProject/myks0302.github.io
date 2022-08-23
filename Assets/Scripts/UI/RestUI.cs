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
        SpawnSystem.instance.WAVE += 1;

        SpawnSystem.instance.NUM_CLOSE = SpawnSystem.instance.mosterWaves[SpawnSystem.instance.WAVE].num_close;
        SpawnSystem.instance.NUM_RANGE = SpawnSystem.instance.mosterWaves[SpawnSystem.instance.WAVE].num_range;
        SpawnSystem.instance.NUM_DRONE = SpawnSystem.instance.mosterWaves[SpawnSystem.instance.WAVE].num_drone;

        SpawnSystem.instance.REMAIN = SpawnSystem.instance.NUM_CLOSE + SpawnSystem.instance.NUM_RANGE + SpawnSystem.instance.NUM_DRONE;

        this.gameObject.SetActive(false);

        //â �ݱ�
        gameObject.SetActive(false);

        gunController.enabled = true;
        playUI.SetActive(true);      
        HandedInputSelector.gameObject.SetActive(false);

        _ = SpawnSystem.instance.StartCoroutine("WaveSystem");
    }
}
