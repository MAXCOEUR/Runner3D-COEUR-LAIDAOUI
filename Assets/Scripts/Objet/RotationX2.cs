using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationX2 : MonoBehaviour
{
    private float rotationSpeed = 30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
