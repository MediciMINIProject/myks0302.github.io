using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //NavAgent를 사용하기 위한 준비

public class Enemy : HP
{
    #region 몬스터 구분
    public enum EnemyType { Close, Range, Suicide }; //몬스터 공격 형태
    public static EnemyType enemyType;

    public enum EnemyRank { Normal, Cadre}; //몬스터 등급
    public static EnemyRank enemyRank;
    #endregion

    #region 몬스터 스펙
    public float speed; //적 이동 속도
    #endregion

    #region 몬스터 AI
    public GameObject Target; //추적할 적 : 바리게이트

    public NavMeshAgent NavMeshAgent; //AI 이식 준비
    float distance; //자신과 타겟간의 거리
    #endregion

    #region 몬스터 상태
    bool isDead; //사망 상태 여부
    #endregion

    #region 파티클 및 애니메이션 연동
    public GameObject[] enemtprefabs; //캐릭터 연동(3종류)

    public Animator[] animators; //애니메이션 연동
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;

        //최초 체력 배정 
        switch (enemyType)
        {
            case EnemyType.Close:
                switch (enemyRank)
                {
                    case EnemyRank.Normal:
                        STARTHP = 125;
                        break;
                    
                    case EnemyRank.Cadre:
                        STARTHP = 200;
                        break;
                }

                break;
            case EnemyType.Range:
                switch (enemyRank)
                {
                    case EnemyRank.Normal:
                        STARTHP = 80;
                        break;

                    case EnemyRank.Cadre:
                        STARTHP = 140;
                        break;
                }
                break;
            
            case EnemyType.Suicide:
                switch (enemyRank)
                {
                    case EnemyRank.Normal:
                        STARTHP = 100;
                        break;

                    case EnemyRank.Cadre:
                        STARTHP = 150;
                        break;
                }
                break;
        }
    }

    private void OnCollisionEnter(Collision collision) //자폭 프로세스()
    {
        
    }

    void Dead()
    {
        if (HITPOINT < 0) //현재 체력 < 0
        {
            isDead = true; //사망상태 활성화

        }
        
        //사망 애니메이션 작동

        //2초후 삭제
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
