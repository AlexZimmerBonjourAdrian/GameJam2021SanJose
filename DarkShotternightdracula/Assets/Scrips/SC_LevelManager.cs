using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SC_LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Musica
    

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuHelp()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

