using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetJetons : MonoBehaviour

{
    public int speed=50;
    public GameObject player;

    void Start()

    {

    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 diff = player.transform.position - transform.position;
        float curDistance = diff.sqrMagnitude;
            if (player.GetComponent<MyPlayer>().isMagnet != false && curDistance < 500f)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }

    }

}