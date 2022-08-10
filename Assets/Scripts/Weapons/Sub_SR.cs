using UnityEngine;

public class Sub_SR : MonoBehaviour
{
    #region 이펙트 관련

    public GameObject srEffect; //총기 사격

    #endregion

    public Transform Bar_transform;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SR_Shoot()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); //일직선 광선

        RaycastHit hitInfo; //부딧친 상대 확인

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.name.Contains("Enemy"))
            {
                Debug.Log("Hit!");

                float Dis_SR = Vector3.Distance(Bar_transform.position, hitInfo.transform.position); //거리 구하기

                //Enemy에게 너 총 맞았어
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                if (Dis_SR >= 30)
                {
                    Debug.Log("아주 강한 피해");
                }
                else if (Dis_SR < 30 && Dis_SR <= 20)
                {
                    Debug.Log("강한 피해");
                }
                else if (Dis_SR < 20 && Dis_SR <= 10)
                {
                    Debug.Log("약한 피해");
                }
                else if (Dis_SR < 10)
                {
                    Debug.Log("아주 약한 피해");
                }

                /*
                //
                
                //적 데미지
                enemy.TakeDamage(damage);

                //적 밀려남
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(hitInfo.transform.position * push_Pow, ForceMode.Impulse);
                */

            }
        }

        Instantiate(srEffect, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

