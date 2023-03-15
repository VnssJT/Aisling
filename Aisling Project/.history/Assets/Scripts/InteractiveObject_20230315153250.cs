using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public void triggered() {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player entered");
        }
    }
}
