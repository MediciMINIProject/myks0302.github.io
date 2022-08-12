using UnityEngine;

public class Sub_SG : MonoBehaviour
{
    #region 이펙트 관련

    //public GameObject sgEffect; //총기 사격

    public GameObject[] sgEffect;
    #endregion

    int damage;
    float push_Pow;

    public Transform muzzle;

    //탄환 흩트리기
    Vector3 cluster;

    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        push_Pow = 5.0f;

        cluster = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
    }

    public void SG_Shoot()
    {
        Ray ray = new(muzzle.transform.position, muzzle.transform.forward); //일직선 광선

        RaycastHit hitInfo; //부딧친 상대 확인
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag("Enemy"))
            {
                GameObject bi = Instantiate(sgEffect[0]);
                bi.transform.position = hitInfo.point;

                bi.transform.forward = hitInfo.normal;

                ParticleSystem ps = bi.GetComponent<ParticleSystem>();
                ps.Stop();
                ps.Play();


                // Enemy에게 너 총 맞았어
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                //적 데미지
                enemy.TakeDamage(damage);

                //적 밀려남
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * -push_Pow, ForceMode.Impulse);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        

    }
}

