using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private bool debugOrientation = true;

    private void Awake() {
        GameObject.Instantiate(playerPrefab, transform.position, transform.rotation);
    }
    
    private void Update() {
        if(debugOrientation) transform.FindChild.Ena
    }
}
