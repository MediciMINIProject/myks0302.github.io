using System;
using System.Collections;
using TMPro;
using UnityEngine;


[Serializable]
public class MosterWave
{
    public static int wave;

    public int nor_close; //일반 근접
    public int nor_range; //일반 원거리
    public int nor_drone; //일반 자폭
}
public class SpawnSystem : MonoBehaviour
{
    public static SpawnSystem instance;

    private void Awake()
    {
        SpawnSystem.instance = this;
    }

    public Transform[] spawnPoints; //소환 위치 받음

    public Close close;
    public Range range;
    public Suicide suicide; //3종류의 몬스터 프리팹 받기

    public MosterWave[] mosterWaves;

    int wavecount; //현재 웨이브

    int waveremain; //남은 적 수

    public GameObject restUI;
    public GameObject clearUI;

    public TextMeshProUGUI waveUI;
    public TextMeshProUGUI remainUI;

    void Spawn_Close(int count) //소환 기본틀
    {
        for (int i = count; i > 0; i--)
        {
            int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);

            Transform spawnPoint = spawnPoints[random_point];
            _ = Instantiate(close.gameObject, spawnPoint);
        }
    }

    void Spawn_Range(int count) //소환 기본틀
    {
        for (int i = count; i > 0; i--)
        {
            int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);

            Transform spawnPoint = spawnPoints[random_point];
            _ = Instantiate(range.gameObject, spawnPoint);
        }
    }

    void Spawn_Drone(int count) //소환 기본틀
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

    public void NextWave() //버튼 이식
    {
        wavecount++;

        //시간 흐르게 하기
        Time.timeScale = 1;

        //창
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
            //일시정지
            Time.timeScale = 0;

            //창
            restUI.SetActive(true);
        }
    }
}
