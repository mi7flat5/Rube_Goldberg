using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysUp : MonoBehaviour {
    public GameObject cam;
	// Use this for initialization
	void Start () {
        cam = GameObject.Find("VRCamera");
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion alwaysUp = Quaternion.Euler(transform.rotation.x, 1, transform.rotation.z);
        transform.forward = -cam.transform.forward;
	}
}
