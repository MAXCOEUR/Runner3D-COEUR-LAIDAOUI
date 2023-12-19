using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GourndCheck : MonoBehaviour
{
    private bool isGround = false;

    public bool getIsGround()
    {
        return isGround;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter");
        isGround = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnCollisionExit");
        isGround = false;

    }
}
