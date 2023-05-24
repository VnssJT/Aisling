using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("TELEPORTER: activated");
            other.gameObject.SetActive(false);
            other.transform.position = destination.position;
            other.gameObject.SetActive(true);
        }
    }
}
