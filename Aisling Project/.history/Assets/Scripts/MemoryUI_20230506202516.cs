using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MemoryUI : MonoBehaviour
{
    string videoRootName = "videoTest";
    VideoPlayer videoPlayer;

    void displayVideoMemory(MemoryManager.MemoryType memoryType, MemoryManager.MemoryIndex memoryID){
        string videoName = videoRootName + memoryID;
        videoPlayer.clip = (VideoClup)Resources.Load()
    }
}
