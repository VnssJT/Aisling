using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        //if(vcam != null) Debug.Log("camera found");
    }

    void OnEnable(){
        PlayerSpawnerController.OnSpawned += FollowPlayer;
    }

    private void OnDisable() {
        PlayerSpawnerController.OnSpawned -= FollowPlayer;
    }

    public void FollowPlayer(){
        player = ;
        vcam.Follow = player.transform;
    }
}
