﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{ 
    public int toggle;
    private GameObject platform;
    private RubeGameLogic logic;
    // Use this for initialization
    void Start()
    {
        logic = GameObject.Find("GameLogic").GetComponent<RubeGameLogic>();
        platform = GameObject.Find("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().isKinematic && Vector3.Distance(transform.position, platform.transform.position) > 2.5)
            logic.ResetGame();

    }
    void OnTriggerEnter(Collider collider)
    {
        toggle ^= 1;
        if (toggle == 1)
        {
            if (collider.CompareTag("Floor"))
            {

                logic.ResetGame();

            }
        }
    }
}
