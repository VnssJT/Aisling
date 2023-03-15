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
        var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void Update(){
        if(player == null){
            player = GameObject.FindWithTag("Player");
            Debug.Log("Looking for the player...");
        }else{
            Debug
            vcam.Follow = player.transform;
        }
    }
}
