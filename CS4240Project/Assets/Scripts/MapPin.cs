using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MapPin : MonoBehaviour
{

    public SteamVR_TrackedObject trackedObject;
    public GameObject info;

    private GameObject pin = null;
    private SteamVR_Controller.Device device;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetPressDown(triggerButton) && pin != null)
        {
            changeScene();
        }
    }

    public void changeScene()
    {
        OnPointerClick();
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
        if (TourManager.SetCameraPosition != null)
        {
            Debug.Log("camera not null");
        }

        info.gameObject.SetActive(!info.gameObject.activeInHierarchy);
        pin = null;

    }

    private void OnTriggerEnter(Collider other)
    {
        pin = other.gameObject;
        //OnPointerClick(null);
    }

    private void OnTriggerExit(Collider other)
    {
        pin = null;
    }
}
