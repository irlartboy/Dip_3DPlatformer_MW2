using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
 
    public void MainMenuButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
