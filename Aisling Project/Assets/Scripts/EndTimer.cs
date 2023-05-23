using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTimer : MonoBehaviour
{
    float timeSinceStarted = 0;
    [SerializeField] float endTime = 7;
    //[SerializeField] Image blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStarted += Time.deltaTime;

        if(timeSinceStarted > endTime)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    /*IEnumerator fadeOut()
    {
        
        yield return null;
    }*/
        
}
