using UnityEngine;

public class GunController : MonoBehaviour
{

    public static GunController instance;

    private void Awake()
    {
        GunController.instance = this;
    }

    public Transform[] grabHands; // ¼Õ À§Ä¡

    public Gun[] selectedGun;
    Gun startGun;

    public bool is_lefthands;

    // Start is called before the first frame update
    void Start()
    {
        is_lefthands = false;

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

        if (is_lefthands == true)
        {
            startGun = Instantiate(startedGun, grabHands[1].position, grabHands[1].rotation);
            startGun.transform.parent = grabHands[1];
        }
        else
        {
            startGun = Instantiate(startedGun, grabHands[0].position, grabHands[0].rotation);
            startGun.transform.parent = grabHands[0];
        }

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
