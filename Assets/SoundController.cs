using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class SoundController : MonoBehaviour, ITrackableEventHandler
{
    public AudioClip[] aClips;
    public GameObject[] Card;
    public AudioSource myAudioSource;
    public AudioSource bgAudioSource;
    public AudioClip BGAudio;
    public Toggle m_toggle;
    string dinoName;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        bgAudioSource = GetComponent<AudioSource>();

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES
    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        bgAudioSource.clip = BGAudio;
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            //OnTrackingFound();
            bgAudioSource.Play();
            bgAudioSource.loop = true;
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            //OnTrackingLost();
            foreach (var card in Card)
            {
                card.SetActive(false);
            }
            bgAudioSource.Pause();
            myAudioSource.Stop();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            //OnTrackingLost();
            foreach (var card in Card)
            {
                card.SetActive(false);
            }
            bgAudioSource.Stop();
            myAudioSource.Stop();
        }
    }

    #endregion // PUBLIC_METHODS

 
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        //if(Input.touchCount >0 && Input.touches[0].phase == TouchPhase.Began)
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit))
            {
                dinoName = Hit.transform.tag;
                switch(dinoName)
                {
                    case "trex":
                        
                        foreach (var card in Card)
                        {
                            card.SetActive(false);
                        }
                        //bgAudioSource.Stop();
                        Card[0].SetActive(true);
                        myAudioSource.clip = aClips[0];
                        myAudioSource.Play();
                
                        Debug.Log("TrexClicked");
                        break;
                    case "triceratop":
                        
                        foreach (var card in Card)
                        {
                            card.SetActive(false);
                        }
                        Card[1].SetActive(true);
                        myAudioSource.clip = aClips[1];
                        myAudioSource.Play();
                        Debug.Log("TriceraClicked");
                        break;
                    case "compsog":
                       
                        foreach (var card in Card)
                        {
                            card.SetActive(false);
                        }
                        Card[2].SetActive(true);
                        myAudioSource.clip = aClips[2];
                        myAudioSource.Play();
                        Debug.Log("CompyClicked");
                        break;
                    case "pteranodon":
                        
                        foreach (var card in Card)
                        {
                            card.SetActive(false);
                        }
                        Card[3].SetActive(true);
                        myAudioSource.clip = aClips[3];
                        myAudioSource.Play();
                        Debug.Log("pteraClicked");
                        break;
                    case "velocirap":
                        
                        foreach (var card in Card)
                        {
                            card.SetActive(false);;
                        }
                        Card[4].SetActive(true);
                        //bgAudioSource.Stop();
                        myAudioSource.clip = aClips[4];
                        myAudioSource.Play();
                        Debug.Log("velocClicked");
                        break;
                    case "landform":
                        foreach(var card in Card)
                        {
                            card.SetActive(false);
                        }
                        bgAudioSource.clip = BGAudio;
                        bgAudioSource.Play();
                        bgAudioSource.loop = true;
                        Debug.Log("landclicked");
                        break;
                    default:
                        foreach (var card in Card)
                        {
                            card.SetActive(false);
                        }
                        myAudioSource.Stop();
                        //bgAudioSource.Play();
                        Debug.Log("Audio should stop");
                        break;
                }
            }
        }
    }
}
