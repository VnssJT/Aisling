using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        
    }


    public void changeScene(string scene)
    {
        EditorSceneManager.LoadScene(scene);
    }
}
