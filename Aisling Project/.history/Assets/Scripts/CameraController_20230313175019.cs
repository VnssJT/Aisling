using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private GameObject tPlayer;

    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void onPlayerLoaded(){
        
    }
}
