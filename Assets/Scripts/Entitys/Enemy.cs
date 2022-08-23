using System.Collections;
using UnityEngine;
using UnityEngine.AI; //NavAgent를 사용하기 위한 준비

public class Enemy : HP
{

    #region 몬스터 AI
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
    }

    public IEnumerator Approach()
    {
        float refreshRate = 0.25f;

        while (Barricade.instance.transform != null)
        {
            Vector3 targetposition = new(Barricade.instance.transform.position.x, 0, Barricade.instance.transform.position.z); //목표 위치 정보 추출

            if (mapAgent.enabled == true)
            {
                mapAgent.SetDestination(targetposition); //목표의 위치을 향해 이동

            }


            yield return new WaitForSeconds(refreshRate); //일정 시간마다 초기화
        }
    }


    private void Update()
    {
    }
}

