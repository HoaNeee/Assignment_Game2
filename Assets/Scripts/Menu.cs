using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void LoadScenceModeEndless()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadScenceLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadScenceMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
