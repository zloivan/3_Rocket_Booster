using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osccilator : MonoBehaviour {

    [SerializeField]
    [Range(0, 1)]
    float MovingFactor;



    [SerializeField]
    Vector3 MovingPosition = new Vector3(10f,10f,10f);


    Vector3 startingPoint;
    [SerializeField] float period = 2f;

    // Use this for initialization
    void Start ()
    {
        startingPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float cicles = Time.time / period; //Grows constantly from 0
        Vector3 offset = MovingPosition * MovingFactor;

        const float Tao = Mathf.PI * 2f; // about 6.28

        float rawSinWave = Mathf.Sin(cicles * Tao);
        MovingFactor = rawSinWave / 2f + 0.5f;
        
        transform.position = startingPoint + offset;
	}
}
