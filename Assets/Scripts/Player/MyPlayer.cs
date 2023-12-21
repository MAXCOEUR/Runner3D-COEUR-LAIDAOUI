using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class MyPlayer : MonoBehaviour
{

    public int DistanceParcouru { get; set; }
    public int CurrentLife { get; private set; }
    public Animator animator;
    public GameObject deathCanvas;

    private int score = 0;
    private int jeton = 0;
    private int addScore = 1;
    

    public int getScore()
    {
        return score;
    }
    public int getJeton()
    {
        return jeton;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - DistanceParcouru >1 )
        {
            DistanceParcouru = (int)transform.position.z;

            score+= addScore;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            ContactPoint contactPoint = collision.contacts[0];

            // Obtient la normale de la collision (direction perpendiculaire à la surface)
            Vector3 normal = contactPoint.normal;

            // Comparaison des carrés des composantes x, y et z de la normale
            float sqrMagnitudeX = normal.x * normal.x;
            float sqrMagnitudeY = normal.y * normal.y;
            float sqrMagnitudeZ = normal.z * normal.z;

            if (sqrMagnitudeZ > sqrMagnitudeX && sqrMagnitudeZ > sqrMagnitudeY)
            {
                Debug.Log("Collision avec Obstacles : La composante Z de la normale est la plus grande.");
                Time.timeScale = 0f;
                if (deathCanvas != null)
                {
                    deathCanvas.SetActive(true);
                }
            }
        }
    }

}
