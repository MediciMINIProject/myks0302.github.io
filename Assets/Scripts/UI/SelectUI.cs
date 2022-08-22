using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SelectUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public TMP_Dropdown mainSelect;
    public void Select_M()
    {
        switch (mainSelect.value)
        {
            case 0:
                Gun_Test.gunType = Gun_Test.GunType.HG;
                break;

            case 1:
                Gun_Test.gunType = Gun_Test.GunType.SMG;
                break;

            case 2:
                Gun_Test.gunType = Gun_Test.GunType.AR;
                break;
        }
    }

    public TMP_Dropdown subSelect;
    public void Select_S()
    {
        switch (subSelect.value)
        {
            case 0:
                Gun_Test.subType = Gun_Test.SubType.SG;
                break;

            case 1:
                Gun_Test.subType = Gun_Test.SubType.SR;
                break;

            case 2:
                Gun_Test.subType = Gun_Test.SubType.GL;
                break;
        }
    }

    public void BacktoLobby()
    {
        SceneManager.LoadScene("Title");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
