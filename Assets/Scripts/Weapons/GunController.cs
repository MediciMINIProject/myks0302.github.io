using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public static GunController instance;

    private void Awake()
    {
        GunController.instance = this;
    }

    public Transform[] grabHands; // 손 위치

    public Gun_Test selectedGun;
    Gun_Test startGun;

    // Start is called before the first frame update
    void Start()
    {

        if (selectedGun != null)
        {
            EquipGun(selectedGun);
        }     

        //게임 도중에는 끄기
    }

    private void EquipGun(Gun_Test startedGun)
    {
        if (startGun != null)
        {
            Destroy(startGun.gameObject);
        }

        
            startGun = Instantiate(startedGun, grabHands[0].position, grabHands[0].rotation);
            startGun.transform.parent = grabHands[0];


    }

    public void MainShoot()
    {
        if (startGun != null)
        {
            startGun.Shooting_M();
        }
    }

    public void SubShoot()
    {
        if (startGun != null)
        {
            startGun.Shooting_S();
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
