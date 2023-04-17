using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    Vector3 cameraDir;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cameraDir = Camera.main.transform.position;
        cameraDir.y = Camera.main.transform.forward.y; // SI
        //cameraDir.y = 0;
        //cameraDir.z = 0;

        transform.rotation = Quaternion.LookRotation(cameraDir);
    }
}

