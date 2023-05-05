using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class endGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        EditorSceneManager.LoadScene(Main M);
    }
}
