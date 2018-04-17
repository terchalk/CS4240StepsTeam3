using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    private GameObject portal;
	// Use this for initialization
	void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
   // private void Update()
   // {
     //   device = SteamVR_Controller.Input((int)trackedObject.index);
     //   if (device.GetPressDown(triggerButton))
     //   {
            //Debug.Log("Hi");
     //   }
   // }
}
