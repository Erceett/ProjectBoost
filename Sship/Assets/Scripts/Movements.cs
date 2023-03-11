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

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateThrust);
        }
        
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; // hareket gereksiz zorlaþýyor
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); //objenin eksenlerine gore kuvvet uygulaniyor.
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }   
        }
        else
        {
            aSource.Stop();
        }
        
    }
}
