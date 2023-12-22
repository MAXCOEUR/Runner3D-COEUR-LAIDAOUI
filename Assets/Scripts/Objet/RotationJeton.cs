using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationJeton : MonoBehaviour
{
    private float rotationSpeed = 30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
