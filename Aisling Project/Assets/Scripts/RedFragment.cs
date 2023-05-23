using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedFragment : MonoBehaviour
{
    private void Awake()
    {
        MemoryUI.onVideoEnded += changeScene;
    }

    private void OnDisable()
    {
        MemoryUI.onVideoEnded -= changeScene;
    }
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<MemoryUI>().displayVideoMemory(MemoryManager.MemoryIndex.RED);
    }

    void changeScene()
    {
        SceneManager.LoadScene("Limbo");
    }

}
