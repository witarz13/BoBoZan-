using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameBase : MonoBehaviour
{

    // Start is called before the first frame update
   
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Main Menu");
    }
}
