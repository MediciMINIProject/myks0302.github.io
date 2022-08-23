using UnityEngine;
using UnityEngine.AI;

public class Close : Enemy
{
    public Animator closeAnimation; //�ൿ �ִϸ��̼�

    protected float distance; //�ڽŰ� Ÿ�ٰ��� �Ÿ�

    public HP_UI hp_ui;

    private NavMeshAgent NavMeshAgent;
    private CapsuleCollider capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        //ü�� ����
        STARTHP = 150;

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

        distance = Vector3.Distance(Barricade.instance.transform.position, this.transform.position);


        if (isDead == false && mapAgent.remainingDistance <= (mapAgent.stoppingDistance + 0.5f))
        {
            closeAnimation.SetTrigger("Attack");//�ٰŸ� ����

        }
        else if (isDead == false && mapAgent.remainingDistance > (mapAgent.stoppingDistance + 0.5f))
        {
            //�̵�
            closeAnimation.SetTrigger("Move");
        }

        if (this.HITPOINT <= 0)
        {
            isDead = true;
        }

        if (isDead == true)
        {
            closeAnimation.SetTrigger("Death");

            Destroy(this.gameObject, 2f);

            //������ �ٵ� �� AI �� Ȱ��ȭ
            NavMeshAgent.enabled = false;
            capsuleCollider.enabled = false;
        }


        if (SpawnSystem.instance.REMAIN <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (isDead == true)
        {
            SpawnSystem.instance.NUM_CLOSE -= 1;
        }
    }
}
