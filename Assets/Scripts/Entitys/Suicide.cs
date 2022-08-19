using UnityEngine;

public class Suicide : Enemy
{
    public GameObject suicideEffect;


    public HP_UI hp_ui;

    // Start is called before the first frame update
    void Start()
    {
        //ü�� ����
        STARTHP = 50;


        this.HITPOINT = this.STARTHP;

        hp_ui.HPSlider.maxValue = STARTHP;

        StartCoroutine(Approach());
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
            //������ �ٵ� �� AI �� Ȱ��ȭ

            SpawnSystem.instance.NUM_DRONE -= 1;

            Destroy(this.gameObject, 3f);

        }
    }





}
