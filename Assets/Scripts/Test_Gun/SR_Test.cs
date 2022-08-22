using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR_Test : MonoBehaviour
{
    public SR_Bullet sr_Bullet;

    public Transform muzzle;

    public void SR_Shoot()
    {
        Instantiate(sr_Bullet, muzzle);
    }

}
