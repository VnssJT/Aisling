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
    private Vector3 panelLocation;
    [SerializeField] GameObject ImagesParent;
    [SerializeField] GameObject ImageHolderPrefab;
    [SerializeField] MemoryImage[] memoryImagesInfo;
    [SerializeField] Dictionary<MemoryManager.MemoryIndex, MemoryImage> memoryImagesDictionary = new Dictionary<MemoryManager.MemoryIndex, MemoryImage>();
    private int currentImageDisplayed = 0;
    private int nImages;
    enum MemoryUIState
    {
        CLOSED,
        DIPLAYING_VIDEO,
        DISPLAYING_IMAGES
    }
    MemoryUIState memoryUIState = MemoryUIState.CLOSED;

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

        // Create dictionary
        foreach (MemoryImage memImage in memoryImagesInfo)
        {
            memoryImagesDictionary.Add(memImage.memoryID, memImage);
        }
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
        // Set ImagesParent active
        ImagesParent.SetActive(true);

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

    void OnPrevButtonPressed(){
        // If it is not the first image
        if(currentImageDisplayed > 0){
            currentImageDisplayed--;
            ImagesParent.transform.position = transform.position + (gameObject.GetComponent<RectTransform>();)
        }

    }

    void OnNextButtonPressed(){

    }
    
}
