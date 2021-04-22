using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject CreditsUI;

    public void Credits()
    {
        CreditsUI.SetActive(true);
    }

    public void CreditsBack()
    {
        CreditsUI.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
