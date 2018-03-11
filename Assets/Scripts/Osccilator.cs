using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osccilator : MonoBehaviour {

    [SerializeField]
    [Range(0, 1)]
    float MovingFactor;

    [SerializeField]
    Vector3 MovingPosition;

    Vector3 startingPoint;
	// Use this for initialization
	void Start ()
    {
        startingPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 offset = MovingPosition * MovingFactor;

        transform.position = startingPoint + offset;
	}
}
