using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawn : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;
    public GameObject ball;
    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        Debug.Log("fuck");
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }
	
	// Update is called once per frame
	void Update () {
        

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Vector3 spawnLoc = transform.position;
            spawnLoc.y += 0.05f;
            Instantiate(ball, spawnLoc, transform.rotation);
            Debug.Log("fuck");
        }

    }
}
