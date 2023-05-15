using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MemoryUI : MonoBehaviour
{

    string videoRootName = "videoTest";
    VideoPlayer videoPlayer;
    [SerializeField] GameObject videoUI;

    #region Singleton
    public static MemoryUI instance;
    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one instance of MemoryUI found!");
            Destroy(gameObject);
        } 
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private void Start() {
        videoPlayer = videoUI.GetComponent<VideoPlayer>();
        
        videoUI.SetActive(false);

        // Event to tell when the video is over
        videoPlayer.loopPointReached += VideoEndReached;
    }

    private void OnDisable() {
        videoPlayer.loopPointReached -= VideoEndReached;
    }

    public void displayVideoMemory(MemoryManager.MemoryIndex memoryID){
        // Choose video file
        string videoName = videoRootName + memoryID;
        //Debug.Log("MEMORYUI " + videoName);
        videoPlayer.clip = (VideoClip) Resources.Load("Videos/" + videoName);

        // Set VideoPlayer active
        videoUI.SetActive(true);
        videoPlayer.Play();
    }

    void VideoEndReached(UnityEngine.Video.VideoPlayer vp){
        videoUI.SetActive(false);
    }

    public void displayImages(MemoryManager.MemoryIndex memoryID){
        // Choose image file
    }
}
