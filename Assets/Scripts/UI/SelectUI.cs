using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectUI : MonoBehaviour
{
    public GunController gunController;

    private void Awake()
    {
        Weapon_M[0].SetActive(false);
        Weapon_M[1].SetActive(false);
        Weapon_M[2].SetActive(false);

        Weapon_S[0].SetActive(false);
        Weapon_S[1].SetActive(false);
        Weapon_S[2].SetActive(false);
    }

    private void Start()
    {
        
    }

    public TMP_Dropdown mainSelect;
    public GameObject[] Weapon_M;
    public void Select_M()
    {
        switch (mainSelect.value)
        {
            case 0:
                Gun_Test.gunType = Gun_Test.GunType.HG;
                Weapon_M[0].SetActive(true);
                Weapon_M[1].SetActive(false);
                Weapon_M[2].SetActive(false);
                break;

            case 1:
                Gun_Test.gunType = Gun_Test.GunType.SMG;
                Weapon_M[0].SetActive(false);
                Weapon_M[1].SetActive(true);
                Weapon_M[2].SetActive(false);
                break;

            case 2:
                Gun_Test.gunType = Gun_Test.GunType.AR;
                Weapon_M[0].SetActive(false);
                Weapon_M[1].SetActive(false);
                Weapon_M[2].SetActive(true);
                break;
        }
    }

    public TMP_Dropdown subSelect;
    public GameObject[] Weapon_S;
    public void Select_S()
    {
        switch (subSelect.value)
        {
            case 0:
                Gun_Test.subType = Gun_Test.SubType.SG;
                Weapon_S[0].SetActive(true);
                Weapon_S[1].SetActive(false);
                Weapon_S[2].SetActive(false);
                break;

            case 1:
                Gun_Test.subType = Gun_Test.SubType.SR;
                Weapon_S[0].SetActive(false);
                Weapon_S[1].SetActive(true);
                Weapon_S[2].SetActive(false);
                break;

            case 2:
                Gun_Test.subType = Gun_Test.SubType.GL;
                Weapon_S[0].SetActive(false);
                Weapon_S[1].SetActive(false);
                Weapon_S[2].SetActive(true);
                break;
        }
    }

    public TMP_Dropdown levelSelect;
    public Image[] level_image;
    public Text level_info;
    public void Select_L()
    {
        switch (levelSelect.value)
        {
            case 0:
                GameManager.level = GameManager.Level.Easy;

                level_image[0].gameObject.SetActive(true);
                level_image[1].gameObject.SetActive(false);
                level_image[2].gameObject.SetActive(false);

                level_info.text = "안드로이드만을 겨냥한 소규모 사이버 테러" + "\n"
                      + "바리케이드의 자동 수복 시스템이 정상 작동되어, 매 라운드마다 자동으로 최대 수치로 수복됩니다.";
                break;

            case 1:
                GameManager.level = GameManager.Level.Normal;

                level_image[0].gameObject.SetActive(false);
                level_image[1].gameObject.SetActive(true);
                level_image[2].gameObject.SetActive(false);

                level_info.text = "일부 시스템의 정전을 동반한 대규모 사이버 테러 입니다." + "\n"
                    + "바리케이드의 자동 수복 시스템에 일부 오류가 발생하여, 매 라운드마다 소진된 체력의 일부만을 수복합니다."
                    + "재생 값은 무작위로 정해지며, 작동을 아예 하지 않을 수도 있습니다.";
                break;

            case 2:
                GameManager.level = GameManager.Level.Hard;

                level_image[0].gameObject.SetActive(false);
                level_image[1].gameObject.SetActive(false);
                level_image[2].gameObject.SetActive(true);

                level_info.text = "대규모 정전을 동반한 무차별 사이버 테러 입니다." + "\n"
                   + "바리케이드의 자동 수복 시스템이 마비되어, 자동 수복 되지 않습니다.";

                break;
        }
    }

    public void BacktoLobby()
    {
        gunController.enabled = false;
        SceneManager.LoadSceneAsync("Title");
    }

    public void StartGame()
    {
        gunController.enabled = true;
        SceneManager.LoadSceneAsync("Game");
    }

}

