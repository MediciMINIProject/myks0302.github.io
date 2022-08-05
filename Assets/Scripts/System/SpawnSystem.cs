using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Transform[] spawnPoints; //소환 위치 받음

    public Close close;
    public Range range;
    public Suicide suicide; //3종류의 몬스터 프리팹 받기

    int[] wave = new int[10]; //웨이브 수


    void Spawn() //소환
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
