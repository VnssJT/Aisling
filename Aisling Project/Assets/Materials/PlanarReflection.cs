using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanarReflection : MonoBehaviour
{
    Vector2 Resolution;

    [SerializeField] Camera ReflectionCamera;
    [SerializeField] RenderTexture ReflectionTexture;
    [SerializeField] int ReflectionResolution;

    private void LateUpdate()
    {
        ReflectionCamera.fieldOfView = Camera.main.fieldOfView;
        ReflectionCamera.transform.position = new Vector3(Camera.main.transform.position.x, -Camera.main.transform.position.y, Camera.main.transform.position.z);
        //ReflectionCamera.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        ReflectionCamera.transform.rotation = Quaternion.Euler(-Camera.main.transform.eulerAngles.x - 5, 0f, 0f);
        //ReflectionCamera.transform.rotation = Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);


        Resolution = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);

        ReflectionTexture.Release();
        ReflectionTexture.width = Mathf.RoundToInt(Resolution.x) * ReflectionResolution / Mathf.RoundToInt(Resolution.y);
        ReflectionTexture.height = ReflectionResolution;
      }
}
