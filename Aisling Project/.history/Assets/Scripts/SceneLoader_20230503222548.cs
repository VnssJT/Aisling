using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void changeScene(string scene)
    {
        EditorSceneManager.LoadScene(scene);
    }
}
