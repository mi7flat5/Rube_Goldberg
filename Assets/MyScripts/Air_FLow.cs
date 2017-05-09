using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air_FLow : MonoBehaviour {
    public float fanSpeed = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collider)
    {
       // collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3();
       if(collider.CompareTag("Play_Ball"))
        collider.gameObject.GetComponentInParent<Rigidbody>().AddForce(transform.forward * fanSpeed, ForceMode.Impulse);

    }
}
