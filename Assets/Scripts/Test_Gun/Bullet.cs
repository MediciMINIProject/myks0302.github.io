using UnityEngine;

public class Bullet : MonoBehaviour
{
    int bullet_damage;

    Rigidbody bullet_body;

    // Start is called before the first frame update
    void Start()
    {
        switch (Gun_Test.gunType)
        {
            case Gun_Test.GunType.HG:
                bullet_damage = 50;              
                break;
            case Gun_Test.GunType.SMG:
                bullet_damage = 15;               
                break;
            case Gun_Test.GunType.AR:
                bullet_damage = 25;
                break;
        }
        bullet_body = GetComponent<Rigidbody>();

        Destroy(gameObject, 3.0f);

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
            Destroy(gameObject);
        }

    }
}
