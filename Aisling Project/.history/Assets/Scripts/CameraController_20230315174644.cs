using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private GameObject player;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        //if(vcam != null) Debug.Log("camera found");
    }

    void OnEnable(){
        PlayerSpawnerController.PlayerSpawned += On
    }

    public void Update(){
        if(player == null){
            player = GameObject.FindWithTag("Player");
            //Debug.Log("Looking for the player...");
        }else{
            //Debug.Log("Plaer found");
            vcam.Follow = player.transform;
        }
    }
}
