using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAngular : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collider)
    {
         collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3();
        collider.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3();
        //collider.gameObject.GetComponentInParent<Rigidbody>().AddForce(transform.forward * fanSpeed, ForceMode.Impulse);
        collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
