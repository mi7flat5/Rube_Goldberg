﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    public float throwForce = 1.5f;
    // Use this for initialization
    public float swipeSum;
    public Vector2 touchLast;
    public Vector2 touchCurrent;
    public float distance;
    public bool hasSwipedLeft;
    public bool hasSwipedRight;
    public MenuManager menuManager;
    private GameObject objectParent;
   
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
       
    }
	
	// Update is called once per frame
	void Update () {

        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (menuManager)
        {
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
                menuManager.ActivateCurrent();
            }
            if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
                distance = touchCurrent.x - touchLast.x;
                touchLast = touchCurrent;
                swipeSum += distance;
                if (!hasSwipedRight)
                {
                    if (swipeSum > 0.5f)
                    {
                        swipeSum = 0;
                        SwipeRight();
                        hasSwipedRight = true;
                        hasSwipedLeft = false;
                    }
                }
                if (!hasSwipedLeft)
                {
                    if (swipeSum < -0.5f)
                    {
                        swipeSum = 0;
                        SwipeLeft();
                        hasSwipedLeft = true;
                        hasSwipedRight = false;
                    }
                }

            }
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                swipeSum = 0;
                touchCurrent = new Vector2(0, 0);
                touchLast = new Vector2(0, 0);
                hasSwipedLeft = false;
                hasSwipedRight = false;
                
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                menuManager.SpawnCurrentObject();
                menuManager.DactivateCurrent();
            }
        }
	}

    private void SwipeLeft()
    {
        menuManager.MenuLeft();
    }

    private void SwipeRight()
    {
        menuManager.MenuRight();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Throwable"))
        {
            if(device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                ThrowObject(col);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip) ) 
            {
                GrabObject(col);
            }
            if (menuManager && device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)&& menuManager.bDestroyObject())
            {
               GrabObject(col);
            }
        }
    }

    private void GrabObject(Collider col)
    {
        if (menuManager && menuManager.bDestroyObject())
        {
            Destroy(col.gameObject);
            device.TriggerHapticPulse(2000);
            Debug.Log("object destroyed, trigger down");
            return;
        }
     
       //bjectParent = col.transform.parent.gameObject;
        col.transform.SetParent(gameObject.transform);
        col.GetComponent<Rigidbody>().isKinematic = true;
        device.TriggerHapticPulse(2000);
       
        Debug.Log("object touched, trigger down");
    }

    private void ThrowObject(Collider col)
    {
         col.transform.SetParent(null);
        Debug.Log(col.name);
        switch (col.gameObject.name) {

            case "BuildingBlock(Clone)": return;
            case "pipe(Clone)": return;
            case "Elbow(Clone)": return;
            case "ConveyorObject(Clone)": return;
         
            default:
                Rigidbody rigidB = col.GetComponent<Rigidbody>();
                rigidB.isKinematic = false;
                rigidB.velocity = device.velocity * throwForce;
                rigidB.angularVelocity = device.angularVelocity;
                break;

        }
       
            
        
        Debug.Log("object thrown");
    }
}
