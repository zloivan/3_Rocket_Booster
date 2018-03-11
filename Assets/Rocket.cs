using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    #region Private Fields
    enum State { Alive, Dead, Trancequent }
    State state = State.Alive;
    Rigidbody rocketRigidbody;
    AudioSource audioSource;
    #endregion

    #region Public Fields
    [SerializeField]
    float ThroatPower = 100f;
    [SerializeField]
    float RotationSpeed = 100f;
    [SerializeField]
    float TimeLoadingNextLevel = 1f;
    [SerializeField]
    float DeathTimer = 1f;

    [SerializeField] AudioClip DeathSound;
    [SerializeField] AudioClip FinishSound;
    [SerializeField] AudioClip ThrustSound;

    [SerializeField] ParticleSystem ExplosionParticle;
    [SerializeField] ParticleSystem SuccesParticle;
    [SerializeField] ParticleSystem ThrustParticle;
    private bool collisionsAreDesabled = false;
    #endregion


    void Start ()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	
	void Update ()
    {
        if (state==State.Alive)
        {
            RespoundThrust();
            RespoundRotate();
        }
        ReactOnDebugInput();
    }

    private void ReactOnDebugInput()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionsAreDesabled = !collisionsAreDesabled;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state!=State.Alive || collisionsAreDesabled)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("We just hited an FRIENDLY [ " + collision.collider.name+" ]");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        ThrustParticle.Stop();
        SuccesParticle.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(FinishSound);
        state = State.Trancequent;
        Invoke("LoadNextLevel", TimeLoadingNextLevel);
    }

    private void StartDeathSequence()
    {
        ThrustParticle.Stop();
        ExplosionParticle.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(DeathSound);
        state = State.Dead;
        Invoke("RestartGame", DeathTimer);
    }

    private void RestartGame()
    {
        
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.sceneCountInBuildSettings > currentSceneIndex+1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Got some FUEL");

    }
    private void RespoundThrust()
    {

        float thrustPerFPS = ThroatPower * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) //thrust the ship
        {
            ApplyThrust(thrustPerFPS);
        }
        else
        {
            ThrustParticle.Stop();
            audioSource.Stop();
        } 
        
    }

    private void ApplyThrust(float throatFps)
    {
        rocketRigidbody.AddRelativeForce(Vector3.up * throatFps);
        ThrustParticle.Play();

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(ThrustSound);
        }
    }

    private void RespoundRotate()
    {

        rocketRigidbody.freezeRotation = true;//Freeze rocket when rotating

        float rotationFps = RotationSpeed * Time.deltaTime;
        if ( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationFps);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotationFps);
        }
        
        rocketRigidbody.freezeRotation = false; //Unfreeze rocket when stop rotating.
    }

    
}
