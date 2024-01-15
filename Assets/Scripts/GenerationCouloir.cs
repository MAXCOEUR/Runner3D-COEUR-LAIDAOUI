using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerationCouloir : MonoBehaviour
{
    public GameObject prefabToInstantiate;

    public GameObject Player;
    public GameObject FistCouloir;


    private List<GameObject> couloirs = new List<GameObject>();

    private long conteur = 1;
    void Start()
    {
        couloirs.Add(FistCouloir);
    }

    // Update is called once per frame
    void Update()
    {
        if(couloirs.Last().transform.position.z - Player.transform.position.z < 100)
        {
            GameObject instantiatedPrefab = Instantiate(prefabToInstantiate);
            instantiatedPrefab.transform.parent = gameObject.transform;
            instantiatedPrefab.transform.position = new Vector3(0f, 0f, conteur * 12f);
            couloirs.Add(instantiatedPrefab);
            conteur++;
        }
        if(couloirs.First().transform.position.z - Player.transform.position.z < -12)
        {
            GameObject delete = couloirs.First();
            couloirs.Remove(delete);
            Destroy(delete);
        }
    }
}
