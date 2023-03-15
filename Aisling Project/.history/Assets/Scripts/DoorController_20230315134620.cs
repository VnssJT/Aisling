using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private int room;
    [SerializeField] private int spawnerID;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            //Debug.Log("going to room " + room);
            
            PlayerSpawnerController.lastSpawnerID = spawnerID;
            EditorSceneManager.LoadScene(room);
        }    
    }
}
