using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    private GameObject[] playerSpawners;
    [SerializeField] private GameObject playerPrefab;
    public static int lastSpawnerID = 0;


    public delegate void PlayerSpawned();
    public static event PlayerSpawned OnSpawned;

    // Start is called before the first frame update
    void Start()
    {

        spawnPlayer();
    }
    private void OnEnable()
    {
        MazeAlgo.OnGenerated += spawnPlayer;        
    }

    private void OnDisable() {
        MazeAlgo.OnGenerated -= spawnPlayer;
    }


    void spawnPlayer(){
        if (playerSpawners == null){
            playerSpawners = GameObject.FindGameObjectsWithTag("PlayerSpawner");
        }
        /*Debug.Log("[PLAYERSPAWNERCONTROLLER] Current scene: " + EditorSceneManager.GetActiveScene().name);
        Debug.Log("number of spawners in scene: " + playerSpawners.Length);
        Debug.Log("lastSpawnerID: " + lastSpawnerID);*/

        foreach (GameObject spawner in playerSpawners)
        {
            //look for all the spawners in the scene until finding the one that lastSpawnerID == spawner.SpawnerID
            if(spawner.GetComponent<PlayerSpawner>().SpawnerID == lastSpawnerID){
                // Instatiate player in that spawner's position
                //Debug.Log("PLAYER SPAWNER CONTROLLER: Instantiating player");
                GameObject.Instantiate(playerPrefab, spawner.transform.position, spawner.transform.rotation);

                // Invoke spawned event
                OnSpawned?.Invoke();

                break;
            }
        }
    }

}
