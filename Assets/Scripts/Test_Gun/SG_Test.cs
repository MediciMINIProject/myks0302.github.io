using System.Collections.Generic;
using UnityEngine;

public class SG_Test : MonoBehaviour
{
    // Start is called before the first frame update

    public Pellet pellet;
    public Transform muzzle;

    int pellets = 8; // ÅºÈ¯ ¼ö
    float spreadAngle = 2.5f; //Èð¾îÁö´Â Á¤µµ

    List<Quaternion> sgShell;

    private void Awake()
    {
        sgShell = new List<Quaternion>(pellets);

        for (int i = 0; i < pellets; i++)
        {
            sgShell.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    void Start()
    {

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

    // Update is called once per frame
    void Update()
    {

    }
}
