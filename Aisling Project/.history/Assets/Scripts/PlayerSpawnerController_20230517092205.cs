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




    }


    void spawnPlayer(){
        
    }

}
