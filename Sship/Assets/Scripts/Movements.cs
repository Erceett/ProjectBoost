using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movements : MonoBehaviour
{
    Rigidbody rb;
    AudioSource aSource;

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotateThrust = 100f;

    [SerializeField] ParticleSystem thrustParticle;
    [SerializeField] ParticleSystem leftRotateParticle;
    [SerializeField] ParticleSystem rightRotateParticle;

    [SerializeField] AudioClip engineSound;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();;
    }


    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            LeftRotation();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RightRotation();
        }
        else
        {
            StopRotation();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); //objenin eksenlerine gore kuvvet uygulaniyor.
        if (!aSource.isPlaying)
        {
            aSource.PlayOneShot(engineSound);
        }
        if (!thrustParticle.isPlaying)
        {
            thrustParticle.Play();
        }
    }

    private void StopThrusting()
    {
        aSource.Stop();
        thrustParticle.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; // hareket gereksiz zorlaþýyor
    }

    private void RightRotation()
    {
        ApplyRotation(-rotateThrust);
        if (!leftRotateParticle.isPlaying)
        {
            leftRotateParticle.Play();
        }
    }

    private void LeftRotation()
    {
        ApplyRotation(rotateThrust);
        if (!rightRotateParticle.isPlaying)
        {
            rightRotateParticle.Play();
        }
    }

    private void StopRotation()
    {
        rightRotateParticle.Stop();
        leftRotateParticle.Stop();
    }

    


}
