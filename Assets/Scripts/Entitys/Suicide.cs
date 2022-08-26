using UnityEngine;
using UnityEngine.AI;

public class Suicide : Enemy
{
    public GameObject suicideEffect;
    public HP_UI hp_ui;

    private NavMeshAgent NavMeshAgent;
    private BoxCollider BoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        BoxCollider = GetComponent<BoxCollider>();

        switch (rank)
        {
            case Rank.Nor:
                //체력 배정
                STARTHP = 50;
                NavMeshAgent.speed = 7.5f;
                break;

            case Rank.Eli:
                //체력 배정
                STARTHP = 100;
                NavMeshAgent.speed = 9f;
                break;
        }

        this.HITPOINT = this.STARTHP;

        hp_ui.HPSlider.maxValue = STARTHP;

        StartCoroutine(Approach());
    }

    // Update is called once per frame
    void Update()
    {
        hp_ui.HPSlider.value = HITPOINT;

        if (mapAgent.remainingDistance <= (mapAgent.stoppingDistance + 0.5f))
        {
            GameObject exp = Instantiate(suicideEffect);
            exp.transform.position = this.transform.position;

            isDead = true;

            switch (rank)
            {
                case Rank.Nor:
                    Barricade.instance.GetComponent<HP>().TakeDamage(100);
                    break;

                case Rank.Eli:
                    Barricade.instance.GetComponent<HP>().TakeDamage(250);
                    break;
            }

            Destroy(this.gameObject);
            Destroy(exp, 2.0f);
        }


        if (this.HITPOINT <= 0)
        {
            isDead = true;
        }

        if (isDead == true)
        {
            Destroy(this.gameObject, 2f);

            this.transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);

            //리지드 바디 및 AI 비 활성화
            NavMeshAgent.enabled = false;
            BoxCollider.enabled = false;
        }

        if (SpawnSystem.instance.REMAIN <= 0 || Time.timeScale == 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnDisable()
    {

        switch (rank)
        {
            case Rank.Nor:
                SpawnSystem.instance.NUM_DRONE -= 1;
                break;

            case Rank.Eli:
                SpawnSystem.instance.NUM_DRONE_E -= 1;
                break;
        }

    }
}
