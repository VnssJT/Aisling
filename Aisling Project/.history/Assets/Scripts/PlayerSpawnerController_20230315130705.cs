using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    private GameObject[] playerSpawners;
    [SerializeField] private GameObject playerPrefab;
    private static int lastSpawnerID;

    // Start is called before the first frame update
    void Start()
    {
        if (playerSpawners == null){
            playerSpawners = GameObject.FindGameObjectsWithTag("PlayerSpawners");
        }

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
