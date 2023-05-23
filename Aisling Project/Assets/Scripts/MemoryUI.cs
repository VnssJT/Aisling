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
    //[SerializeField] GameObject imagesUI;
    float easing = 0.5f;
    [SerializeField] GameObject ImagesParent;
    [SerializeField] GameObject ImagesPanelWithButtons;
    [SerializeField] GameObject ImageHolderPrefab;
    [SerializeField] MemoryImage[] memoryImagesInfo;
    Dictionary<MemoryManager.MemoryIndex, MemoryImage> memoryImagesDictionary = new Dictionary<MemoryManager.MemoryIndex, MemoryImage>();
    private int currentImageDisplayed = 0;
    private int nImages;
    private Vector3 originalImagesParentPos;

    // EVENTS
    public delegate void OnMemoryUI();
    public static OnMemoryUI onVideoEnded;

    private void Start() {
        // Set video settings
        videoPlayer = videoUI.GetComponentInChildren<VideoPlayer>();
        videoPlayer.waitForFirstFrame = true;
        videoUI.SetActive(false);

        // Event to tell when the video is over
        videoPlayer.loopPointReached += VideoEndReached;


        // Create dictionary
        foreach (MemoryImage memImage in memoryImagesInfo)
        {
            memoryImagesDictionary.Add(memImage.memoryID, memImage);
        }

        // Set original ImagesParent position
        originalImagesParentPos = ImagesParent.transform.position;
    }

    private void OnEnable() {
        Memory.OnImagesOpened += displayImages;
        Memory.OnVideoOpened += displayVideoMemory;
    }

    private void OnDisable() {
        //videoPlayer.loopPointReached -= VideoEndReached;
        Memory.OnImagesOpened -= displayImages;
        Memory.OnVideoOpened -= displayVideoMemory;
    }

    public void displayVideoMemory(MemoryManager.MemoryIndex memoryID){
        //Debug.Log("MEMORY UI: displaying video...");
        // Choose video file
        string videoName = videoRootName + memoryID;
        //Debug.Log("MEMORYUI " + videoName);
        videoPlayer.clip = (VideoClip) Resources.Load("Videos/" + videoName);

        // Set VideoPlayer active
        videoUI.SetActive(true);
        videoPlayer.Play();
    }

    void VideoEndReached(UnityEngine.Video.VideoPlayer vp){
        onVideoEnded?.Invoke();
        videoUI.SetActive(false);
    }

    public void displayImages(MemoryManager.MemoryIndex memoryID){
        //Debug.Log("MEMORY UI: displaying images...");
        // Set ImagesParent active
        ImagesPanelWithButtons.SetActive(true);

        // clear ImagesParent
        foreach (Transform image in ImagesParent.transform)
        {
            GameObject.Destroy(image.gameObject);
        }

        // Get memoryImageInfo
        MemoryImage memImage = memoryImagesDictionary[memoryID];
        nImages = memImage.nImages;

        // For eevery image the memory holds
        for (int i = 0; i < nImages; i++)
        {
            // Create an instance
            GameObject newImage = Instantiate(ImageHolderPrefab, Vector3.zero, Quaternion.identity, ImagesParent.transform);

            // Set the srpite
            newImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + memoryID.ToString() + "_" + i);
        }

        // Set current image displayed to 0
        currentImageDisplayed = 0;
        ImagesParent.transform.position = originalImagesParentPos;

    }

    //To make the sliding smoother
    IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds) {
        float t = 0f;
        while (t <= 1.0) {
            t += Time.deltaTime / seconds;
            ImagesParent.transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }


    public void OnPrevButtonPressed(){
        // If it is not the first image
        if(currentImageDisplayed > 0){
            currentImageDisplayed--;
            Vector3 newPos = ImagesParent.transform.position + new Vector3(960, 0); // for some reason it's 960 i have no idea why
            StartCoroutine(SmoothMove(ImagesParent.transform.position, newPos, easing));
        }

    }

    public void OnNextButtonPressed(){
        if(currentImageDisplayed < ImagesParent.transform.childCount - 1){
            currentImageDisplayed++;
            Vector3 newPos = ImagesParent.transform.position +  new Vector3(-960, 0); // for some reason it's 960 i have no idea why
            StartCoroutine(SmoothMove(ImagesParent.transform.position, newPos, easing));
        }
    }

    public void OnCloseButtonPressed(GameObject currentPanelDisplaying){
        currentPanelDisplaying.SetActive(false);
    }
    
}
