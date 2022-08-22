using UnityEngine;

public class SR_Bullet : MonoBehaviour
{
    int bullet_damage;

    Rigidbody bullet_body;

    int pierce;

    // Start is called before the first frame update
    void Start()
    {
        bullet_damage = 100;

        bullet_body = GetComponent<Rigidbody>();
        
        Destroy(gameObject, 3.0f);
        
        pierce = 3;

        Debug.Log("응애 나 애기 저격총");
    }

    // Update is called once per frame
    void Update()
    {
        bullet_body.AddForce(transform.forward, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(bullet_damage);
            bullet_damage -= 10;

            pierce--;
            
            if (pierce == 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
