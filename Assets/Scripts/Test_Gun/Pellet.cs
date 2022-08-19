using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    int pellet_damage;

    Rigidbody pellet_body;

  
    // Start is called before the first frame update
    void Start()
    {
        pellet_damage = 30;

        pellet_body = GetComponent<Rigidbody>();

        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        pellet_body.AddForce(transform.forward, ForceMode.Impulse);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(pellet_damage);
            Destroy(gameObject);
        }
    }
}
