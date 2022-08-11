using UnityEngine;

public class Sub_SR : MonoBehaviour
{
    #region 이펙트 관련

    public GameObject srEffect; //총기 사격

    #endregion

    public Transform Bar_transform;

    int damage;
    float push_Pow;

    public Transform muzzle; //발사 위치

    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        push_Pow = 5.0f;
    }


    public void SR_Shoot()
    {
        Ray ray = new Ray(muzzle.transform.position, muzzle.transform.transform.forward); //일직선 광선

        RaycastHit hitInfo; //부딧친 상대 확인

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag("Enemy"))
            {
                Debug.Log("Hit!");

                float Dis_SR = Vector3.Distance(Bar_transform.position, hitInfo.transform.position); //거리 구하기

                //Enemy에게 너 총 맞았어
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                if (Dis_SR >= 30)
                {
                    enemy.TakeDamage(damage);

                    //적 밀려남
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                }
                else if (Dis_SR < 30 && Dis_SR <= 20)
                {
                    enemy.TakeDamage(damage / 2);

                    //적 밀려남
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 2, ForceMode.Impulse);
                }
                else if (Dis_SR < 20 && Dis_SR <= 10)
                {
                    enemy.TakeDamage(damage / 3);

                    //적 밀려남
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 3, ForceMode.Impulse);
                }
                else if (Dis_SR < 10)
                {
                    enemy.TakeDamage(damage / 4);

                    //적 밀려남
                    enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow / 4, ForceMode.Impulse);
                }

                /*
                //
                
                //적 데미지
                enemy.TakeDamage(damage);

                //적 밀려남
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                */

                GameObject bi = Instantiate(srEffect);
                bi.transform.position = hitInfo.point;

                bi.transform.forward = hitInfo.normal;

                ParticleSystem ps = bi.GetComponent<ParticleSystem>();
                ps.Stop();
                ps.Play();

            }
        }

        Instantiate(srEffect, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

