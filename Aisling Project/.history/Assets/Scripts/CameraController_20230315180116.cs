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
        PlayerSpawnerController.OnSpawned += FollowPlayer;
        //if(vcam != null) Debug.Log("camera found");
    }

    void OnEnable(){
        PlayerSpawnerController.OnSpawned += FollowPlayer;
    }

    private void OnDisable() {
        PlayerSpawnerController.OnSpawned -= FollowPlayer;
    }

    public void FollowPlayer(){
        Debug.Log("Camera following player")
        vcam.Follow = GameObject.FindWithTag("Player").transform;
    }
}
