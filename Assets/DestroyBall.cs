using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    public int toggle;
   

    // Use this for initialization
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        toggle ^= 1;
        if (toggle == 1)
        {
            if (collider.CompareTag("Floor"))
            {
                
                gameObject.SendMessageUpwards("ResetGame");

            }
        }
    }
}
