using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class MyPlayer : MonoBehaviour
{

    public int DistanceParcouru { get; set; }
    public int CurrentLife { get; private set; }
    public Animator animator;

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
}
