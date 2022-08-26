using UnityEngine;
using UnityEngine.AI;

public class Range : Enemy
{
    public Animator rangeAnimation; //행동 애니메이션

    protected float distance; //자신과 타겟간의 거리

    public HP_UI hp_ui;

    private NavMeshAgent NavMeshAgent;
    private CapsuleCollider capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        
        switch (rank)
        {
            case Rank.Nor:
                //체력 배정
                STARTHP = 100;
                NavMeshAgent.speed = 3.5f;
                mapAgent.stoppingDistance = 10f;
                break;

            case Rank.Eli:
                //체력 배정
                STARTHP = 150;
                NavMeshAgent.speed = 4.5f;
                mapAgent.stoppingDistance = 17.5f;
                break;
        }

        StartCoroutine(Approach());

        this.HITPOINT = this.STARTHP;

        hp_ui.HPSlider.maxValue = STARTHP;

    }



    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Barricade.instance.transform.position, this.transform.position);

        hp_ui.HPSlider.value = HITPOINT;

        if (isDead == false && mapAgent.remainingDistance <= (mapAgent.stoppingDistance + 0.5f))
        {
            rangeAnimation.SetTrigger("Attack");

        }
        else if (isDead == false && mapAgent.remainingDistance > (mapAgent.stoppingDistance + 0.5f))
        {
            rangeAnimation.SetBool("Walk", true);
        }
        
        if (this.HITPOINT <= 0)
        {
            isDead = true;
        }

        if (isDead == true)
        {
            rangeAnimation.SetTrigger("Dead");

            Destroy(this.gameObject, 3f);

            //리지드 바디 및 AI 비 활성화
            NavMeshAgent.enabled = false;
            capsuleCollider.enabled = false;
        }

        if (SpawnSystem.instance.REMAIN <= 0 || Time.timeScale == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (isDead == true)
        {
            switch (rank)
            {
                case Rank.Nor:
                    SpawnSystem.instance.NUM_RANGE -= 1;
                    break;

                case Rank.Eli:
                    SpawnSystem.instance.NUM_RANGE_E -= 1;
                    break;

            }
        }
    }

 
}
