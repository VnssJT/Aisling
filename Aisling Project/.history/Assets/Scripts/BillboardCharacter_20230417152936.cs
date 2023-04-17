using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCharacter : MonoBehaviour
{

    Vector3 cameraDir;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cameraDir = Camera.main.transform.position - transform.position;
        cameraDir.y = Camera.main.transform.forward.y; 

        transform.rotation = Quaternion.LookRotation(cameraDir);
    }
}

