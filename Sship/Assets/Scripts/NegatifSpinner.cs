using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegatifSpinner : MonoBehaviour
{
    [SerializeField] float zRotation = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -zRotation);
    }
}
