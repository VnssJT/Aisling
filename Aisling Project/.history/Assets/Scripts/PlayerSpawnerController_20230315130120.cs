using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    [SerializeField] private PlayerSpawner[] playerSpawners;
    [SerializeField] private GameObject playerPrefab;
    private static int lastSpawnerID;

    // Start is called before the first frame update
    void Start()
    {
        //look for all the spawners in the room until finding the one that lastSpawnerID == spawner.SpawnerID
        // Instatiate player in that 
    }


}
