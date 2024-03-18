using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_scrept : MonoBehaviour
{
    // Start is called before the first frame update
    
   

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("PlayScene");
    }
    // Update is called once per frame
    public void quitGames()
    {
        Application.Quit();
    }
}
