using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private void Awake() {
        GameObject.Instantiate(playerPrefab, transform.position, transform.rotation);
    }
    
    private void Update() {
        transform.Find("orientation").gameObject.SetActive(debugOrientation);
    }
}
