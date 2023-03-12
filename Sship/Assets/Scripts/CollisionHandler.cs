using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float invokeTime = 1f;

    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;

    AudioSource aSource;
    
    bool isTransitioning = false;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning){return; }
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                {
                    Debug.Log("This things is FRIEND");
                }
                break;
            case "Finished":
                {
                    StartNextLevelSequence();
                }
                break;
            default:
                {
                    StartCrashSequence();
                }
                break;
        }
    }

    private void StartNextLevelSequence()
    {
        isTransitioning = true;
        GetComponent<Movements>().enabled= false;
        GetComponent<AudioSource>().Stop();
        aSource.PlayOneShot(successSound, 1f);
        GetComponent<Rigidbody>().freezeRotation = true;
        successParticle.Play();
        Invoke("NextLevel", invokeTime);
    }

    private void StartCrashSequence()
    {
        isTransitioning = true;
        GetComponent<Movements>().enabled = false;
        GetComponent<AudioSource>().Stop();
        aSource.PlayOneShot(crashSound, 0.4f);
        crashParticle.Play();
        Invoke("ReloadLevel", invokeTime);
    }


    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Congrats!!");
        }
        else 
        { 
            SceneManager.LoadScene(nextSceneIndex);
        }
  
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
