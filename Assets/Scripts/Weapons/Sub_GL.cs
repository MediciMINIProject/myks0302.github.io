using UnityEngine;

public class Sub_GL : MonoBehaviour
{
    #region 이펙트 관련

    public GameObject glEffect; //총기 사격

    #endregion

    float radius = 5.0f; //폭발 반경
    int damage = 75; //주는 피해



    // Start is called before the first frame update
    void Start()
    {

    }

    public void GL_Shoot() //발사 매커니즘
    {
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 40.0f, ForceMode.Impulse);
    }

    void Explode() //폭발 매커니즘
    {
        Collider[] enemys = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearenemy in enemys)
        {
            Enemy enemy = nearenemy.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(glEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
