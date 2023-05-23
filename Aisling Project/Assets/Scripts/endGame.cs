using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    enum Ending
    {
        STAY,
        MOVE_ON
    }

    [SerializeField] Ending ending;

    private void OnTriggerEnter(Collider other) {
        switch (ending)
        {
            case Ending.STAY:
                SceneManager.LoadScene("EndStay");
                break;
            case Ending.MOVE_ON:
                SceneManager.LoadScene("EndMoveOn");
                break;
            default:
                break;
        }
        
    }
}
