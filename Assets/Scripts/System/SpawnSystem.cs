using System;
using System.Collections;
using TMPro;
using UnityEngine;


[Serializable]
public class MosterWave
{
    public static int wave;

    public int num_close; //�Ϲ� ����
    public int num_range; //�Ϲ� ���Ÿ�
    public int num_drone; //�Ϲ� ����


}
public class SpawnSystem : MonoBehaviour
{
    public int NUM_CLOSE
    {
        get { return mosterWaves[wavecount].num_close; }

        set 
        {
            mosterWaves[wavecount].num_close = value;
        }
    }

    public int NUM_RANGE
    {
        get { return mosterWaves[wavecount].num_range; }

        set
        {
            mosterWaves[wavecount].num_range = value; 
        }
    }

    public int NUM_DRONE 
    {
        get { return mosterWaves[wavecount].num_drone; }

        set
        {
            mosterWaves[wavecount].num_drone = value; 
        }
    }


    public static SpawnSystem instance;

    private void Awake()
    {
        SpawnSystem.instance = this;
    }

    public Transform[] spawnPoints; //��ȯ ��ġ ����

    public Close close;
    public Range range;
    public Suicide suicide; //3������ ���� ������ �ޱ�

    public MosterWave[] mosterWaves;

    public int wavecount; //���� ���̺�

    public int waveremain; //���� �� ��

    public TextMeshProUGUI waveUI;
    public TextMeshProUGUI remainUI;

    
    void Spawn_Close(int count) //��ȯ �⺻Ʋ
    {
        for (int i = count; i > 0; i--)
        {
            int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);

            Transform spawnPoint = spawnPoints[random_point];
            _ = Instantiate(close.gameObject, spawnPoint);
        }
    }

    void Spawn_Range(int count) //��ȯ �⺻Ʋ
    {
        for (int i = count; i > 0; i--)
        {
            int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);

            Transform spawnPoint = spawnPoints[random_point];
            _ = Instantiate(range.gameObject, spawnPoint);
        }
    }

    void Spawn_Drone(int count) //��ȯ �⺻Ʋ
    {
        for (int i = count; i > 0; i--)
        {
            int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);

            Transform spawnPoint = spawnPoints[random_point];
            _ = Instantiate(suicide.gameObject, spawnPoint);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        wavecount = 0;

        StartCoroutine(WaveSystem());
    }

    public IEnumerator WaveSystem()
    {
        yield return new WaitForSeconds(5.0f);

        Spawn_Close(mosterWaves[wavecount].num_close);
        Spawn_Range(mosterWaves[wavecount].num_range);
        Spawn_Drone(mosterWaves[wavecount].num_drone);
    }

  

    // Update is called once per frame
    void Update()
    {
        waveremain = mosterWaves[wavecount].num_close + mosterWaves[wavecount].num_range + mosterWaves[wavecount].num_drone;

        waveUI.text = "Wave" + "\n" + (wavecount + 1) + " / " + mosterWaves.Length;
        remainUI.text = "Remain" + "\n" + waveremain;      
    }
}
