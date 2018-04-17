using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {

	public SteamVR_TrackedObject trackedObject;
	public Button button = null;
	public Sprite currentImage = null;
	public Sprite hoverImage = null;

	private SteamVR_Controller.Device device;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input((int)trackedObject.index);
		if (device.GetPressDown(triggerButton) && button != null) {
			if (button.tag == "mainButton") {
				changeButton (); 
				changeScene ();
			} else {
				changeButton ();
			}
		}
	}

	private void changeButton() {
		currentImage = button.targetGraphic.GetComponent<Sprite>();
		button.image.sprite = hoverImage;
		StartCoroutine (Delay());
		button.image.sprite = currentImage;
	}

	private void changeScene() {
		SceneManager.LoadScene ("Main", LoadSceneMode.Single);
	}

	private void OnTriggerEnter(Collider other) {
		button = other.gameObject.GetComponent<Button>();;
	}

	private void OnTriggerExit(Collider other) {
		button = null;
	}

	IEnumerator Delay() {
		yield return new WaitForSeconds(2);
	}
}
