using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GeneratedMap : MonoBehaviour
{
    public GameObject player = null;
    public GameObject TruePattern = null;
    public List<GameObject> Pattern = new List<GameObject>();
    // Start is called before the first frame update

    void Start()
    {
        for (int i = -7; i < 3; i++)
        {
            Pattern.Add(Instantiate(TruePattern, new Vector3(0, 0f, i * 6f), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update() {
            float position = player.transform.position.z;


            foreach (var it in Pattern)
            {
                if (it.transform.position.z < position -50)
                {
                Pattern.Remove(it);
                Destroy(it);
                    Pattern.Add(Instantiate(TruePattern, new Vector3(0, 0f, Pattern.Last().transform.position.z + 12f), Quaternion.identity));
                }

            }
    }
}
