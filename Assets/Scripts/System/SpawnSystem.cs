using System;
using System.Collections;
using TMPro;
using UnityEngine;


[Serializable]
public class MosterWave
{
    public static int wave;

    public int nor_close; //�Ϲ� ����
    public int nor_range; //�Ϲ� ���Ÿ�
    public int nor_drone; //�Ϲ� ����
}
public class SpawnSystem : MonoBehaviour
{
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

    int wavecount; //���� ���̺�

    int waveremain; //���� �� ��

    public GameObject restUI;
    public GameObject clearUI;

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

        restUI.SetActive(false);
        clearUI.SetActive(false);

        StartCoroutine(WaveSystem());
    }

    IEnumerator WaveSystem()
    {
        yield return new WaitForSeconds(5.0f);

        Spawn_Close(mosterWaves[wavecount].nor_close);
        Spawn_Range(mosterWaves[wavecount].nor_range);
        Spawn_Drone(mosterWaves[wavecount].nor_drone);



        if (waveremain == mosterWaves.Length - 1)
        {
            restUI.SetActive(false);
            clearUI.SetActive(true);
        }
    }

    public void NextWave() //��ư �̽�
    {
        wavecount++;

        //�ð� �帣�� �ϱ�
        Time.timeScale = 1;

        //â
        restUI.SetActive(false);

        StartCoroutine(WaveSystem());
    }

    // Update is called once per frame
    void Update()
    {
        waveremain = mosterWaves[wavecount].nor_close + mosterWaves[wavecount].nor_range + mosterWaves[wavecount].nor_drone;

        waveUI.text = "Wave" + "\n" + (wavecount + 1) + " / " + mosterWaves.Length;
        remainUI.text = "Remain" + "\n" + waveremain;

        if (waveremain == 0)
        {
            //�Ͻ�����
            Time.timeScale = 0;

            //â
            restUI.SetActive(true);
        }
    }
}
