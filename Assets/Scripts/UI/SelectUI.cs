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
                Gun.gunType = Gun.GunType.HG;
                break;

            case 1:
                Gun.gunType = Gun.GunType.SMG;
                break;

            case 2:
                Gun.gunType = Gun.GunType.AR;
                break;
        }
    }

    public TMP_Dropdown subSelect;
    public void Select_S()
    {
        switch (subSelect.value)
        {
            case 0:
                Gun.subType = Gun.SubType.SG;
                break;

            case 1:
                Gun.subType = Gun.SubType.SR;
                break;

            case 2:
                Gun.subType = Gun.SubType.GL;
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
