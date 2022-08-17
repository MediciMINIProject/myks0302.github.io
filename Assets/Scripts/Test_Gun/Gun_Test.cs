using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Test : MonoBehaviour
{
    public Transform muzzle; //ÃÑ±¸

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Shooting() 
    {
        Ray ray = new(muzzle.position, muzzle.forward * 30);

        RaycastHit hitinfo;

        if (Physics.Raycast(ray, out hitinfo)) 
        {
            Debug.Log("hit!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) 
        {
            Shooting();
        }
    }
}
