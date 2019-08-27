using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject playPanel;
    public GameObject optionsPanel;

    public void PlayButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void OptionsButton()
    {
        playPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        optionsPanel.SetActive(false);
        playPanel.SetActive(true);
    }


    
}
