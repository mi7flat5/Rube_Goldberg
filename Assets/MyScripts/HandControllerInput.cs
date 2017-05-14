using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllerInput : MonoBehaviour
{

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    // To teleport
    private LineRenderer laser;                     //- teleport laser
    public GameObject teleportAimerObject;           //- teleport cylinder
    public Vector3 teleportLocation;
    public GameObject player;                       //- you
    public LayerMask laserMask;                     //- which layer mask we can teleport to 
    public float yNudge = 1f;                 //- specific to teleport aimer height

    //- To dash
    public float dashSpeed = 0.1f;
    private bool isDashing;
    private float lerpTime;
    private Vector3 dashStartPosition;

    //- To walk
    public Transform playerCam;
    public float moveSpeed = 1f;
    private Vector3 movementDirection;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        laser = GetComponentInChildren<LineRenderer>();
        teleportAimerObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        //- walking
        //if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        //{
        //    movementDirection = playerCam.transform.forward;
        //    movementDirection = new Vector3(movementDirection.x, 0, movementDirection.z);
        //    movementDirection *= moveSpeed * Time.deltaTime;
        //    player.transform.position += movementDirection;
        //}
       

            ////- dashing
            if (isDashing)
        {
            lerpTime += dashSpeed*Time.deltaTime;
            player.transform.position = Vector3.Lerp(dashStartPosition, teleportLocation, lerpTime);
            if (lerpTime >= 1)
            {
                isDashing = false;
                lerpTime = 0;
            }
        }
         else
         {

        //- teleporting
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                laser.gameObject.SetActive(true);
                laser.SetPosition(0, gameObject.transform.position);
                RaycastHit hit;
              
                if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
                {

                   

                    teleportAimerObject.SetActive(true);

                  
                   // if(hit.transform.CompareTag("Floor"))
                    teleportLocation = hit.point;

                    laser.SetPosition(1, teleportLocation);
                    //- aimer position
                    teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y + yNudge, teleportLocation.z);
                }
                else
                {



                   // teleportAimerObject.SetActive(true);



                    //teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 + transform.position.y, transform.forward.z * 15 + transform.position.z);
                    //RaycastHit groundRay;
                    //if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask))
                    //{

                    //    teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, groundRay.point.y, transform.forward.z * 15 + transform.position.z);
                    //}

                    laser.SetPosition(1, transform.forward * 15 + transform.position);
                    ////- set aimer position

                    //teleportAimerObject.transform.position = teleportLocation + new Vector3(0, yNudge, 0);
                }
            }
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                laser.gameObject.SetActive(false);
                teleportAimerObject.SetActive(false);
               
                  player.transform.position = teleportLocation;
                //dashStartPosition = player.transform.position;
                isDashing = false;//set to true and uncomment previous line to dash
            }
        }
    }
}