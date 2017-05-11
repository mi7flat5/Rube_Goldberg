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
    
    void OnTriggerStay(Collider collider)
    {
        collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3();
       if(collider.name == "Ball"||collider.name == "Ball_throw(Clone)" || collider.name == "TestBall(Clone)")
        collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * fanSpeed, ForceMode.Impulse);

    }
}
