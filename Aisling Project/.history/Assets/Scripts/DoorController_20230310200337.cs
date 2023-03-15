using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using 

public class DoorController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "player"){

        }    
    }
}
