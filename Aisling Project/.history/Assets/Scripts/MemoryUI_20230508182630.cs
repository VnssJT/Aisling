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
    [SerializeField] GameObject imagesUI;
    float easing = 0.5f;
    private Vector3 panelLocation;
    [SerializeField] RectTransform ImagesParent;

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
        // Set video settings
        videoPlayer = videoUI.GetComponent<VideoPlayer>();
        videoPlayer.waitForFirstFrame = true;
        videoUI.SetActive(false);

        // Event to tell when the video is over
        videoPlayer.loopPointReached += VideoEndReached;

        // Set Image objects
        //panelLocation = imagesUI.transform.position;
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
        foreach (RectTransform image in ImagesParent)
        {
            Debug.Log("MEMORYUI ImagesParent child: " + image);
        }
        //clear ImagesParent

        // Assign new children


    }

    //To make the sliding smoother
    IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds) {
        float t = 0f;
        while (t <= 1.0) {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }

    void nextImage(){
        transform.position = panelLocation;
        StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
    }
}
