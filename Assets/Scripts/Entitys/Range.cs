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
        //체력 배정

        STARTHP = 100;

        StartCoroutine(Approach());

        this.HITPOINT = this.STARTHP;

        hp_ui.HPSlider.maxValue = STARTHP;

        NavMeshAgent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }



    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Barricade.instance.transform.position, this.transform.position);

        hp_ui.HPSlider.value = HITPOINT;

        if (isDead == false && mapAgent.remainingDistance <= (mapAgent.stoppingDistance + 0.5f))
        {
            rangeAnimation.SetTrigger("Attack");
            //공격

            //데미지

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


    }

    private void OnDisable()
    {
        SpawnSystem.instance.NUM_RANGE -= 1;
    }
}
