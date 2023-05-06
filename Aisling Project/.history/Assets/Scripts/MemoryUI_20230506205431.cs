using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MemoryUI : MonoBehaviour
{
    static string videoRootName = "videoTest";
    static VideoPlayer videoPlayer;
    [SerializeField]  GameObject videoUI;

    private void Start() {
        videoPlayer = videoUI.GetComponent<VideoPlayer>();
        videoUI.SetActive(false);
    }

    static public void displayVideoMemory(MemoryManager.MemoryIndex memoryID){
        // Choose video file
        string videoName = videoRootName + memoryID;
        Debug.Log("MEMORYUI " + videoName);
        videoPlayer.clip = (VideoClip) Resources.Load("Videos/" + videoName);

        // Set VideoPlayer active
        videoUI.SetActive(true);
        videoPlayer.Play();
    }
}
