using System;
using System.Collections;
using TMPro;
using UnityEngine;


[Serializable]
public class MosterWave
{
    public static int wave;

    public int num_close; //일반 근접
    public int num_range; //일반 원거리
    public int num_drone; //일반 자폭

    public int eli_close; //상급 근접
    public int eli_range; //상급 근접
    public int eli_drone; //상급 근접
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

    public int NUM_CLOSE_E
    {
        get { return mosterWaves[wavecount].eli_close; }

        set
        {
            mosterWaves[wavecount].eli_close = value;
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
    public int NUM_RANGE_E
    {
        get { return mosterWaves[wavecount].eli_range; }

        set
        {
            mosterWaves[wavecount].eli_range = value;
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
    public int NUM_DRONE_E
    {
        get { return mosterWaves[wavecount].eli_drone; }

        set
        {
            mosterWaves[wavecount].eli_drone = value;
        }
    }


    public static SpawnSystem instance;

    private void Awake()
    {
        SpawnSystem.instance = this;
    }

    public Transform[] spawnPoints; //소환 위치 받음

    public Close close;
    public Range range;
    public Suicide suicide; //3종류의 몬스터 프리팹 받기

    public Close close_Elite;
    public Range range_Elite;
    public Suicide suicide_Elite; //3종류의 몬스터 프리팹 받기

    public MosterWave[] mosterWaves;

    int wavecount; //현재 웨이브
    public int WAVE
    {
        get { return wavecount; }
        set
        {
            wavecount = value;
        }
    }

    int waveremain; //남은 적 수
    public int REMAIN
    {
        get { return waveremain; }
        set
        {
            waveremain = value;
        }
    }

    public TextMeshProUGUI waveUI;
    public TextMeshProUGUI remainUI;

    #region 한꺼번에 소환
    public IEnumerator WaveSystem()
    {
        yield return new WaitForSeconds(2.0f);
        Spawn_Close(mosterWaves[wavecount].num_close);
        Spawn_Range(mosterWaves[wavecount].num_range);
        Spawn_Drone(mosterWaves[wavecount].num_drone);
    }
    void Spawn_Close(int count) //한꺼번에 소환
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

    #endregion



    #region 일반 몬스터
    void Close() //소환 기본틀
    {
        int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[random_point];

        _ = Instantiate(close.gameObject, spawnPoint);
    }

    void Range() //소환 기본틀
    {
        int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[random_point];
        _ = Instantiate(range.gameObject, spawnPoint);
    }
    void Drone() //소환 기본틀
    {
        int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[random_point];
        _ = Instantiate(suicide.gameObject, spawnPoint);
    }


    float delay_c;
    float rand_c;
    int count_close = 0;

    float delay_r;
    float rand_r;
    int count_range = 0;


    float delay_d;
    float rand_d;
    int count_drone = 0;
    void Spawn_Rand(int count_c, int count_r, int count_d)
    {
        delay_c += Time.deltaTime;
        delay_r += Time.deltaTime;
        delay_d += Time.deltaTime;

        if (delay_c >= rand_c && count_close < count_c)
        {
            Close();
            delay_c = 0;
            count_close++;
            rand_c = UnityEngine.Random.Range(1f, 2.5f);
        }

        if (count_close == count_c || count_c == 0)
        {
            delay_c = 0;
        }


        if (delay_r >= rand_r && count_range < count_r)
        {
            Range();
            delay_r = 0;
            count_range++;
            rand_r = UnityEngine.Random.Range(1f, 2.5f);
        }

        if (count_range == count_r || count_r == 0)
        {
            delay_r = 0;
        }


        if (delay_d >= rand_d && count_drone <= count_d)
        {
            Drone();
            delay_d = 0;
            count_drone++;
            rand_d = UnityEngine.Random.Range(1f, 2.5f);
        }

        if (count_drone == count_d || count_d == 0)
        {
            delay_d = 0;
        }
    }
    #endregion

    
    #region 상급 몬스터
    float delay_c_eli;
    float rand_c_eli;
    int count_close_eli = 0;

    float delay_r_eli;
    float rand_r_eli;
    int count_range_eli = 0;


    public float delay_d_eli;
    public float rand_d_eli;
    public int count_drone_eli = 0;

    void Close_Elite() //소환 기본틀
    {
        int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[random_point];

        _ = Instantiate(close_Elite.gameObject, spawnPoint);
    }
    void Range_Elite() //소환 기본틀
    {
        int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[random_point];
        _ = Instantiate(range_Elite.gameObject, spawnPoint);
    }


    void Drone_Elite() //소환 기본틀
    {
        int random_point = UnityEngine.Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[random_point];
        _ = Instantiate(suicide_Elite.gameObject, spawnPoint);
    }

    int back_count_d_eli; //백업본을 사용
    void Spawn_Rand_Elite(int count_c_eli, int count_r_eli, int count_d_eli)
    {
        delay_c_eli += Time.deltaTime;
        delay_r_eli += Time.deltaTime;
        delay_d_eli += Time.deltaTime;

        if (delay_c_eli >= rand_c_eli && count_close_eli < count_c_eli)
        {
            Close_Elite();
            delay_c_eli = 0;
            count_close_eli++;
            rand_c_eli = UnityEngine.Random.Range(5f, 8f);
        }

        if (count_close_eli == count_c_eli || count_c_eli == 0)
        {
            delay_c_eli = 0;
        }


        if (delay_r_eli >= rand_r_eli && count_range_eli < count_r_eli)
        {
            Range_Elite();
            delay_r_eli = 0;
            count_range_eli++;
            rand_r_eli = UnityEngine.Random.Range(5f, 8f);
        }

        if (count_range_eli == count_r_eli || count_r_eli == 0)
        {
            delay_r_eli = 0;
        }

        back_count_d_eli = count_d_eli;
        if (delay_d_eli >= rand_d_eli && back_count_d_eli > 0)
        {
            Drone_Elite();
            delay_d_eli = 0;
            back_count_d_eli--;
            rand_d_eli = UnityEngine.Random.Range(5f, 8f);
        }

        if (count_drone_eli == count_d_eli )
        {
            delay_d_eli = 0;
        }

    }
    #endregion

    public void Total_Spawn() 
    {
        Spawn_Rand(NUM_CLOSE, NUM_RANGE, NUM_DRONE);
        Spawn_Rand_Elite(NUM_CLOSE_E, NUM_RANGE_E, NUM_DRONE_E);
    }

    public void Count_Reset() 
    {
        count_close = 0;
        count_range = 0;
        count_drone = 0;

        count_close_eli = 0;
        count_range_eli = 0;
        count_drone_eli = 0;
    }

    public void Enemy_Total(int wave)
    {
        NUM_CLOSE = mosterWaves[wave].num_close;
        NUM_CLOSE_E = mosterWaves[wave].eli_close;

        NUM_RANGE = mosterWaves[wave].num_range;
        NUM_RANGE_E = mosterWaves[wave].eli_range;

        NUM_DRONE = mosterWaves[wave].num_drone;
        NUM_DRONE_E = mosterWaves[wave].eli_drone;

        REMAIN = NUM_CLOSE + NUM_CLOSE_E + NUM_RANGE + NUM_RANGE_E + NUM_DRONE + NUM_DRONE_E;
    }

    public void Total_Random()
    {
        rand_c = UnityEngine.Random.Range(1.25f, 2f);
        rand_r = UnityEngine.Random.Range(1.25f, 2f);
        rand_d = UnityEngine.Random.Range(1.25f, 2f);

        rand_c_eli = UnityEngine.Random.Range(3.5f, 5.0f);
        rand_r_eli = UnityEngine.Random.Range(3.5f, 5.0f);
        rand_d_eli = UnityEngine.Random.Range(3.5f, 5.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Enemy_Total(WAVE);
        //최초 체크

        Total_Random();
    }


    // Update is called once per frame
    void Update()
    {
        Enemy_Total(WAVE);
        //실시간 체크

        Total_Spawn();

        waveUI.text = "Wave" + "\n" + (wavecount + 1) + " / " + mosterWaves.Length;
        remainUI.text = "Remain" + "\n" + waveremain;

        //난이도 표시
        switch (GameManager.level)
        {
            case GameManager.Level.Easy:
                remainUI.text = "Easy" + "\n" + "Remain" + "\n" + waveremain;
                remainUI.color = Color.blue;
                break;
            case GameManager.Level.Normal:
                remainUI.text = "Normal" + "\n" + "Remain" + "\n" + waveremain;
                remainUI.color = Color.black;
                break;
            case GameManager.Level.Hard:
                remainUI.text = "Hard" + "\n" + "Remain" + "\n" + waveremain;
                remainUI.color = Color.red;
                break;
        }
    }
}
