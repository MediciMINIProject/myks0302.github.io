using UnityEngine;
using UnityEngine.AI;

public class Suicide : Enemy
{
    public GameObject suicideEffect;
    public HP_UI hp_ui;

    private NavMeshAgent NavMeshAgent;
    private CapsuleCollider capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        //체력 배정
        STARTHP = 50;


        this.HITPOINT = this.STARTHP;

        hp_ui.HPSlider.maxValue = STARTHP;

        StartCoroutine(Approach());

        NavMeshAgent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        hp_ui.HPSlider.value = HITPOINT;

        if (isDead == false && mapAgent.remainingDistance <= (mapAgent.stoppingDistance + 0.5f))
        {

            this.HITPOINT = 0;

            GameObject exp = Instantiate(suicideEffect);
            exp.transform.position = this.transform.position;

            Barricade.instance.GetComponent<HP>().TakeDamage(100);

            Destroy(this.gameObject);
        }


        if (this.HITPOINT <= 0)
        {
            isDead = true;
        }

        if (isDead == true)
        {
            Destroy(this.gameObject, 3f);

            //리지드 바디 및 AI 비 활성화
            NavMeshAgent.enabled = false;
            capsuleCollider.enabled = false;
        }
    }


    private void OnDisable()
    {
        SpawnSystem.instance.NUM_DRONE -= 1;
    }
}
