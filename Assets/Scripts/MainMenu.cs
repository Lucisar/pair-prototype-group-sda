using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("LR_Prototype");
        Time.timeScale = 1;
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
