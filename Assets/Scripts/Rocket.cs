using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rocketRigidbody;
	// Use this for initialization
	void Start ()
    {
        rocketRigidbody = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))//thrust the ship
        {
            print("Ship is thrustating.");
            rocketRigidbody.AddRelativeForce(Vector3.up);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            print("Rotating left.");
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            print("Rotating right.");
        }
        
    }
}
