using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public abstract void triggered() {
        Debug.Log("Player entered")
    }
}
