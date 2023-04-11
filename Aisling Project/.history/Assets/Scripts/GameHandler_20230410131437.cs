using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";

    [SerializeField] private GameObject unitGameObject;
    //private IUnit unit;

    private void Awake() {
        //unit = unitGameObject.GetComponent<IUnit>();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.S)){
            Save();
        }
        if(Input.GetKeyDown(KeyCode.L)){
            Load();
        }
    }

    private void Save(){
        // Save
        Vector3 playerPosition = unit.
    }
}
