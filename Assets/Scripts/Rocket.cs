using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rocketRigidbody;
    AudioSource thrustAudioSource;
    [SerializeField]
    float ThroatPower = 100f;
    [SerializeField]
    float RotationSpeed = 100f;
	// Use this for initialization
	void Start ()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        thrustAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Thrust();
        Rotate();
    }

    //private void ProcessInput()
    //{
    //    //My variant
    //    //if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.Space))
    //    //{
    //    //    thrustAudioSource.Play();
    //    //}
    //    //if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
    //    //{
    //    //    thrustAudioSource.Stop();
    //    //}


    //}

    private void Thrust()
    {

        float throatFps = ThroatPower * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) //thrust the ship
        {
            //Console message
            print("Ship is thrustating.");
            rocketRigidbody.AddRelativeForce(Vector3.up * throatFps);

            #region Throat Sound
            if (!thrustAudioSource.isPlaying)
            {
                thrustAudioSource.Play();
            }
        }
        else
        {
            thrustAudioSource.Stop();
        } 
        #endregion
    }
    private void Rotate()
    {

        rocketRigidbody.freezeRotation = true;

        float rotationFps = RotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            
            transform.Rotate(Vector3.forward * rotationFps);
            //Console message
            print("Rotating left.");
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotationFps);
            //Console message
            print("Rotating right.");
        }

        rocketRigidbody.freezeRotation = false;
    }

    
}
