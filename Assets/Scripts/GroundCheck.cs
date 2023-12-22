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
    public void setJumpGround()
    {
        isGround = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("OnCollisionEnter");
            isGround = true;
        }
    }
}
