using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{

    public void quitthismiserablelife()
    {
        Application.Quit();   
    }


    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
