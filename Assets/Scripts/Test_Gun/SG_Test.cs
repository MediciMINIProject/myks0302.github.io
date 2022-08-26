using System.Collections.Generic;
using UnityEngine;

public class SG_Test : MonoBehaviour
{
    // Start is called before the first frame update

    public Pellet pellet;
    public Transform muzzle;

    int pellets = 10; // ÅºÈ¯ ¼ö
    float spreadAngle = 3.5f; //Èð¾îÁö´Â Á¤µµ

    List<Quaternion> sgShell;

    private void Awake()
    {
        sgShell = new List<Quaternion>(pellets);

        for (int i = 0; i < pellets; i++)
        {
            sgShell.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    public void SG_Shoot()
    {
        for (int i = 0; i < pellets; i++)
        {
            sgShell[i] = Random.rotation;

            GameObject p = Instantiate(pellet, muzzle.position, muzzle.rotation).gameObject;

            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, sgShell[i], spreadAngle);
        }
    }

}
