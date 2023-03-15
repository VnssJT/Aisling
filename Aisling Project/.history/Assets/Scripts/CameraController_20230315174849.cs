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
        player = GameObject.FindWithTag("Player");
        //if(vcam != null) Debug.Log("camera found");
    }

    void OnEnable(){
        PlayerSpawnerController.OnSpawned += FollowPlayer;
    }

    private void OnDisable() {
        PlayerSpawnerController.OnSpawned -= FollowPlayer;
    }

    public void FollowPlayer(){
        vcam.Follow = player.transform;
    }
}
