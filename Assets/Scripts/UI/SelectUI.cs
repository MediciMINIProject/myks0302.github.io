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

                level_info.text = "�ȵ���̵常�� �ܳ��� �ұԸ� ���̹� �׷�" + "\n"
                      + "�ٸ����̵��� �ڵ� ���� �ý����� ���� �۵��Ǿ�, �� ���帶�� �ڵ����� �ִ� ��ġ�� �����˴ϴ�.";
                break;

            case 1:
                GameManager.level = GameManager.Level.Normal;

                level_image[0].gameObject.SetActive(false);
                level_image[1].gameObject.SetActive(true);
                level_image[2].gameObject.SetActive(false);

                level_info.text = "�Ϻ� �ý����� ������ ������ ��Ը� ���̹� �׷� �Դϴ�." + "\n"
                    + "�ٸ����̵��� �ڵ� ���� �ý��ۿ� �Ϻ� ������ �߻��Ͽ�, �� ���帶�� ������ ü���� �Ϻθ��� �����մϴ�."
                    + "��� ���� �������� ��������, �۵��� �ƿ� ���� ���� ���� �ֽ��ϴ�.";
                break;

            case 2:
                GameManager.level = GameManager.Level.Hard;

                level_image[0].gameObject.SetActive(false);
                level_image[1].gameObject.SetActive(false);
                level_image[2].gameObject.SetActive(true);

                level_info.text = "��Ը� ������ ������ ������ ���̹� �׷� �Դϴ�." + "\n"
                   + "�ٸ����̵��� �ڵ� ���� �ý����� ����Ǿ�, �ڵ� ���� ���� �ʽ��ϴ�.";

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

