using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour {

    bool getBigger = true;
    public float scaleOfSize=1.5f;
    Vector3 initialState;
    Vector3 lastState;
    Collider spherColider;
    // Use this for initialization
	void Start ()
    {
        spherColider = GetComponent<Collider>();
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
