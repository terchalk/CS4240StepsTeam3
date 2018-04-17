using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Hotspot : MonoBehaviour {

    public SteamVR_TrackedObject trackedObject;
    public GameObject ThisPanorama;
    public GameObject TargetPanorama;

    private GameObject portal = null;
    private SteamVR_Controller.Device device;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    void Start()
    {

    }

    // Update is called once per frame
    void Update () 
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetPressDown(triggerButton) && portal != null)
        {
            changeScene();
        }
    }

    public void changeScene()
    {
        if (portal != null)
        {
            OnPointerClick();
        }
    }

    public void OnPointerClick() 
    {
        OnHotspotTransition();
    }

    public void OnHotspotTransition() 
    {
        SetSkyBox();
    }

    private void SetSkyBox() 
    {
        if(TourManager.SetCameraPosition != null)
        {
            Debug.Log("camera not null");
            TourManager.SetCameraPosition(TargetPanorama.transform.position, ThisPanorama.transform.position);
        }
        Debug.Log(portal);
        Debug.Log("Target Pano is " + TargetPanorama + " and this pano is " + ThisPanorama);
        TargetPanorama.gameObject.SetActive(true);
        ThisPanorama.gameObject.SetActive(false);
        portal = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        portal = other.gameObject;
        //OnPointerClick(null);
    }

    private void OnTriggerExit(Collider other)
    {
        portal = null;
    }
}
