using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float room;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "player"){
            EditorSceneManager
        }    
    }
}
