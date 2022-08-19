using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR_Bullet : MonoBehaviour
{
    int bullet_damage;

    Rigidbody bullet_body;

    // Start is called before the first frame update
    void Start()
    {
        bullet_damage = 100;

        bullet_body = GetComponent<Rigidbody>();

        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        bullet_body.AddForce(transform.up, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(bullet_damage);
        }

        Destroy(gameObject);
    }
}
