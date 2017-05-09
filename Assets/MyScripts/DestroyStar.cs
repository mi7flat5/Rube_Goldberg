using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStar : MonoBehaviour {
    private int toggle = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collider)
    {
        toggle ^= 1;
        if (toggle==1)
        {
            if (collider.CompareTag("Play_Ball"))
            {
                GetComponent<AudioSource>().Play();
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
               gameObject.SendMessageUpwards("IncrementStar");
                

            }
        }
    }
   
}
