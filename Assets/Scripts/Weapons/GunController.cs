using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform grabHand; // ¼Õ À§Ä¡

    public Gun[] selectedGun;
    Gun startGun;

    // Start is called before the first frame update
    void Start()
    {
        if (selectedGun != null) 
        {
            EquipGun(selectedGun[0]);
        }
    }

    private void EquipGun(Gun startedGun)
    {
        if (startGun != null)
        {
            Destroy(startGun.gameObject);
        }
        startGun = Instantiate(startedGun, grabHand.position, grabHand.rotation);
        startGun.transform.parent = grabHand;
    }

    public void MainShoot() 
    {
        if (startGun != null) 
        {
            startGun.MainShoot();
        }
    }
    
    public void SubShoot() 
    {
        if (startGun != null)
        {
            startGun.SubShoot();
        }
    }
    
    public void Reload() 
    {
        if (startGun != null)
        {
            startGun.Reload();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
