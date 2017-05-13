using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
     public float Speed = 0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider collider)
    {
        
        if (collider.name == "Ball" || collider.name == "Ball_throw(Clone)" || collider.name == "TestBall(Clone)")
        {
            collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * Speed, ForceMode.Impulse);
            Debug.Log(collider.name);
        }
       
    }
}
