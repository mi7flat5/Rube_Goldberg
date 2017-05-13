using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion alwaysUp = Quaternion.Euler(transform.rotation.x, 1, transform.rotation.z);
        transform.rotation = alwaysUp;
	}
}
