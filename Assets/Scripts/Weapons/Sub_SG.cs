using UnityEngine;

public class Sub_SG : MonoBehaviour
{
    #region 이펙트 관련

    //public GameObject sgEffect; //총기 사격

    public GameObject[] sgEffect;
    #endregion

    public Transform Bar_transform;

    int damage;
    float push_Pow;


    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        push_Pow = 5.0f;
    }

    public void SG_Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward); //일직선 광선

        RaycastHit hitInfo; //부딧친 상대 확인

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag("Enemy"))
            {
                float Dis_SG = Vector3.Distance(Bar_transform.position, hitInfo.transform.position); //거리 구하기

                // Enemy에게 너 총 맞았어
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                if (Dis_SG >= 30)
                {
                    enemy.TakeDamage(damage / 4);

                    //적 밀려남
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 4, ForceMode.Impulse);
                }
                else if (Dis_SG < 30 && Dis_SG <= 20)
                {
                    enemy.TakeDamage(damage / 3);

                    //적 밀려남
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 3, ForceMode.Impulse);
                }
                else if (Dis_SG < 20 && Dis_SG <= 10)
                {
                    enemy.TakeDamage(damage / 2);

                    //적 밀려남
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 2, ForceMode.Impulse);
                }
                else if (Dis_SG < 10)
                {
                    enemy.TakeDamage(damage);

                    //적 밀려남
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                }

                /*
                
                //적 데미지
                enemy.TakeDamage(damage);

                //적 밀려남
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                */

            }
            //GameObject SG_Effect = Instantiate(sgEffect, transform.position, transform.rotation);
            //Destroy(SG_Effect, 0.5f);


            foreach (GameObject pellets in sgEffect)
            {
                GameObject bi = Instantiate(pellets);
                
                bi.transform.position = hitInfo.point;

                bi.transform.forward = hitInfo.normal;

                ParticleSystem ps = bi.GetComponent<ParticleSystem>();
                ps.Stop();
                ps.Play();

            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

