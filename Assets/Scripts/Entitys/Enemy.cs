using System.Collections;
using UnityEngine;
using UnityEngine.AI; //NavAgent를 사용하기 위한 준비

public class Enemy : HP
{
    #region 몬스터 구분(상속 받은 행동에서 사용)
    public enum EnemyRank { Normal, Cadre }; //몬스터 등급
    public static EnemyRank enemyRank;
    #endregion

    #region 몬스터 AI
    public GameObject target; //추적할 적의 위치 : 바리게이트

    public NavMeshAgent mapAgent; //AI 이식 준비
    #endregion

    #region 몬스터 상태
    protected bool isDead; //사망 상태 여부
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        isDead = false; //사망 상태를 false == 살아있음

        mapAgent = GetComponent<NavMeshAgent>(); // 자신에게 있는 에이전트 가져오기
        target = GameObject.FindGameObjectWithTag("Target"); //오브젝트의 위치 가져오기
    }

    IEnumerator Approach()
    {
        float refreshRate = 0.25f;

        while (target != null)
        {
            Vector3 targetposition = new Vector3(target.transform.position.x, 0, target.transform.position.z); //목표 위치 정보 추출

            mapAgent.SetDestination(targetposition); //목표의 위치을 향해 이동

            yield return new WaitForSeconds(refreshRate); //일정 시간마다 초기화
        }
    }

    
    private void Update()
    {
        if (HITPOINT <= 0) 
        {
            isDead = true; //사망 상태를 true 로 변경
        }      
    }
}

