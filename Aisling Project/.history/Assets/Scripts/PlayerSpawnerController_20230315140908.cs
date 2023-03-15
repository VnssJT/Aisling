using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerSpawnerController : MonoBehaviour
{
    private GameObject[] playerSpawners;
    [SerializeField] private GameObject playerPrefab;
    public static int lastSpawnerID = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (playerSpawners == null){
            playerSpawners = GameObject.FindGameObjectsWithTag("PlayerSpawner");
        }
        Debug.Log("[PLAYERSPAWNERCONTROLLER] Current scene: " + EditorSceneManager.GetActiveScene().name);
        Debug.Log("number of spawners in scene: " + playerSpawners.Length);
        Debug.Log("lastSpawnerID: " + lastSpawnerID);

        foreach (GameObject spawner in playerSpawners)
        {
            if(spawner.GetComponent<PlayerSpawner>().SpawnerID == lastSpawnerID){
                GameObject.Instantiate(playerPrefab, spawner.transform.position, spawner.transform.rotation);
                
            }
        }
        //look for all the spawners in the room until finding the one that lastSpawnerID == spawner.SpawnerID
        // Instatiate player in that spawner's position
    }


}
