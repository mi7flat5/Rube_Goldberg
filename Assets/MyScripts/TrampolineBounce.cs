using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBounce : MonoBehaviour {
    public float bounceForce = 4.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collider)
    {
       
       
       if(collider.gameObject.GetComponentInParent<Rigidbody>().angularVelocity.magnitude < 0.14)
        {
            Vector3 randDir= new Vector3(Random.Range(3, 6), Random.Range(3, 6), Random.Range(3, 6));
            collider.gameObject.GetComponentInParent<Rigidbody>().angularVelocity = randDir;
            collider.gameObject.GetComponentInParent<Rigidbody>().AddForce(randDir.normalized, ForceMode.Impulse);
        }
      
        collider.gameObject.GetComponentInParent<Rigidbody>().AddForce(transform.forward * bounceForce, ForceMode.Impulse);

    }

}
