using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MemoryUI : MonoBehaviour
{
    public static MemoryUI instance;
    static string videoRootName = "videoTest";
    static VideoPlayer videoPlayer;
    [SerializeField] GameObject videoUI;

    #region Singleton
    public static MemoryManager instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one instance of Memory Manager found!");
            Destroy(gameObject);
        } 
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion
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
