using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                {
                    Debug.Log("You picked up FUEL");
                }
                break;
            case "Friendly":
                {
                    Debug.Log("This things is FRIEND");
                }
                break;
            case "Finished":
                {
                    NextLevel();
                }
                break;
            default:
                {
                    ReloadLevel();
                }
                break;
        }
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
