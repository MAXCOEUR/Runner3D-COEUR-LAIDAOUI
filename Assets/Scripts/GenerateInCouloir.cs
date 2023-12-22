using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateInCouloir : MonoBehaviour
{
    public GameObject prefabJeton;
    public GameObject prefabX2;

    public List<GameObject> listObstacle = new List<GameObject>();
    public List<GameObject> listObstacleSafe = new List<GameObject>();

    int lineSafe;
    void Start()
    {
        int conteur = 0;

        List<GameObject> ObjetRandomNotSelf = new List<GameObject>();
        ObjetRandomNotSelf.Add(listObstacle[Random.Range(0, listObstacle.Count)]);
        ObjetRandomNotSelf.Add(listObstacle[Random.Range(0, listObstacle.Count)]);

        GameObject ObjetLineSafe = listObstacleSafe[Random.Range(0, listObstacleSafe.Count)];

        lineSafe = Random.Range(-1, 2);

        for (int x = -1; x <= 1; x++)
        {
            if(x == lineSafe)
            {
                GameObject instantiatedPrefab = Instantiate(ObjetLineSafe, gameObject.transform.position, gameObject.transform.rotation);
                instantiatedPrefab.transform.parent = gameObject.transform;
                instantiatedPrefab.transform.position += new Vector3(x*2, 0f, 3f);
            }
            else
            {
                GameObject instantiatedPrefab = Instantiate(ObjetRandomNotSelf[conteur++], gameObject.transform.position, gameObject.transform.rotation);
                instantiatedPrefab.transform.parent = gameObject.transform;
                Debug.Log(gameObject.transform.position.z);
                instantiatedPrefab.transform.position += new Vector3(x * 2, 0f, 3f);
            }
        }

        for (int z = -2; z <= 8; z+=2)
        {
            GameObject instantiatedPrefab = Instantiate(prefabJeton, gameObject.transform.position, gameObject.transform.rotation);
            instantiatedPrefab.transform.parent = gameObject.transform;
            instantiatedPrefab.transform.position += new Vector3(lineSafe * 2, 0.5f, z);
        }

        bool isX2 = Random.Range(1, 101)<20;
        if(isX2)
        {
            int line = randomLineRecusive(lineSafe);
            GameObject instantiatedPrefab = Instantiate(prefabX2, gameObject.transform.position, gameObject.transform.rotation);
            instantiatedPrefab.transform.parent = gameObject.transform;
            instantiatedPrefab.transform.position += new Vector3(line * 2, 0.5f, 1);
        }
    }
    int randomLineRecusive(int x)
    {
        if(x != lineSafe)
        {
            return x;
        }
        return randomLineRecusive(Random.Range(-1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
