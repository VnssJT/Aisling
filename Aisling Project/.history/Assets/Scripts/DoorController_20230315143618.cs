using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private string room;
    [SerializeField] private int spawnerID;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            /*Debug.Log("going to room " + room);
            Debug.Log("[DOORCONTROLLER] Current scene: " + EditorSceneManager.GetActiveScene().name);
            Debug.Log("DOOR changing lastSpawnerID to: " + spawnerID);
            PlayerSpawnerController.lastSpawnerID = spawnerID;
            EditorSceneManager.LoadScene(room);
        }    
    }
}
