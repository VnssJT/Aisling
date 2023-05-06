using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MemoryUI : MonoBehaviour
{
    string videoRootName = "videoTest";
    VideoPlayer videoPlayer;
    [SerializeField] RawImage videoUI;

    private void Start() {
        videoPlayer = videoUI.GetComponent<VideoPlayer>();
    }

    void displayVideoMemory(MemoryManager.MemoryType memoryType, MemoryManager.MemoryIndex memoryID){
        // Choose video file
        string videoName = videoRootName + memoryID;
        videoPlayer.clip = (VideoClip) Resources.Load("Video/" + videoName);

        // Set VideoPlayer active
    }
}
