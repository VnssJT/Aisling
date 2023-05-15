using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private string room;
    [SerializeField] private int spawnerID;
    public bool isBlocked = true;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            if(isBlocked){
                Debug.Log("DOOR CONTROLLER: Access denied");
            } else {
                /*Debug.Log("going to room " + room);
                Debug.Log("[DOORCONTROLLER] Current scene: " + EditorSceneManager.GetActiveScene().name);
                Debug.Log("DOOR changing lastSpawnerID to: " + spawnerID);*/
                PlayerSpawnerController.lastSpawnerID = spawnerID;
                SceneManager.LoadScene(room);
            }

        }    
    }
}