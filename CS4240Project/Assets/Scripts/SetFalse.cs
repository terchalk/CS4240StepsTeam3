using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFalse : MonoBehaviour {

    [SerializeField] public GameObject pano;
	// Use this for initialization
	void Start () {
        pano.gameObject.SetActive(false);
	}
	    
	// Update is called once per frame
	void Update () {
		
	}
}
