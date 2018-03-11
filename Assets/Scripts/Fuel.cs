using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour {

    //TODO fix the sound of picking fuel.
    bool getBigger = true;
    public float scaleOfSize=1.5f;
    Vector3 initialState;
    Vector3 lastState;
    AudioSource soundSource;
    [SerializeField] AudioClip pickingFuelSound;
    //Collider spherColider;
    // Use this for initialization
	void Start ()
    {
        soundSource = GetComponent<AudioSource>();

        //spherColider = GetComponent<Collider>();
        initialState = transform.localScale;
        lastState = transform.localScale * scaleOfSize;
        ChangingScale();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        CheckForSize();
        ChangingScale();
        Rotate();

        
    }
    private void OnTriggerEnter(Collider other)
    {
        soundSource.Stop();
        soundSource.PlayOneShot(pickingFuelSound);
        Destroy(gameObject);
    }
    private void Rotate()
    {
        //transform.localEulerAngles = Vector3.RotateTowards(,,,,);
    }

    private void CheckForSize()
    {
        if (transform.localScale==lastState)
        {
            getBigger = false;
        }
        else
        {
            if (transform.localScale==initialState)
            {
                getBigger = true;
            }
        }
    }

    private void ChangingScale()
    {
        //print("Came in changingScale "+getBigger);
        if (getBigger==true)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, lastState, Time.deltaTime * scaleOfSize);
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, initialState, Time.deltaTime * scaleOfSize);
        }
            
        
        
        //if (transform.localScale.magnitude > target.magnitude)
        //{
        //    target = Vector3.;
        //}
        //else target *= 2f;
        //print(target.x + " " + target.y + " " + target.z + " magnitude: " + target.magnitude);
        //transform.localScale = Vector3.MoveTowards(transform.localScale, target, Time.deltaTime * 2);
    }
}
