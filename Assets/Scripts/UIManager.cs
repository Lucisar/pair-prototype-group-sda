using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameObject levelCompletePanel;

    void Start()
    {
        levelCompletePanel.SetActive(false);
    }

    public void ShowLevelComplete()
    {
        Time.timeScale = 0;
        levelCompletePanel.SetActive(true);
    }


    
    public void OnLevelCompleteButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
