using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class MoveByGest : MonoBehaviour
{
    private Vector2? fingerDown;
    private Coroutine moveCoroutine;
    public float speed = 3f;
    public float changeLineDuration = 0.5f;
    public float rollDuration = 1f;
    public float jumpForce = 5.0f;
    public GourndCheck GourndCheck;
    public Rigidbody moveRigidbody = null;
    private int numerolane = 0;

    private bool isRoll = false;
    private bool isRunLeft = false;
    private bool isRunRight = false;

    public Animator animator;

    private bool hasProcessedTouch = false;

    private void OnEnable()
    {
        UnityEngine.InputSystem.EnhancedTouch.TouchSimulation.Enable();
        UnityEngine.InputSystem.EnhancedTouch.EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        UnityEngine.InputSystem.EnhancedTouch.TouchSimulation.Disable();
        UnityEngine.InputSystem.EnhancedTouch.EnhancedTouchSupport.Disable();
    }

    public void MoveRight()
    {
        isRunRight = true;
        isRunLeft = false;
        numerolane = Math.Min(numerolane + 2, 2);
        RestartMoveCoroutine(numerolane,true);
    }

    public void MoveLeft()
    {
        isRunLeft = true;
        isRunRight = false;
        numerolane = Math.Max(numerolane - 2, -2);
        RestartMoveCoroutine(numerolane,false);
    }

    private void RestartMoveCoroutine(float targetX,bool isRight)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveToX(targetX, isRight));
    }

    IEnumerator MoveToX(float targetX, bool isRight)
    {
        float elapsedTime = 0f;
        float initialX = transform.position.x; 

        while (elapsedTime < changeLineDuration)
        { 
            elapsedTime += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, elapsedTime / changeLineDuration);
            transform.position = new Vector3(Mathf.Lerp(initialX, targetX, t), transform.position.y, transform.position.z);
            yield return null;
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        if(isRight)
        {
            isRunRight = false;
        }
        else
        {
            isRunLeft = false;
        }
    }
    IEnumerator AdjustColliderHeight(float targetHeight)
    {
        CapsuleCollider collider = moveRigidbody.GetComponent<CapsuleCollider>();
        float initialHeight = collider.height;
        float initialY = collider.center.y;

        float newInitialHeight = initialHeight * targetHeight;

        float newInitialY = initialY - (newInitialHeight * (1-targetHeight));

        // Réduire la taille instantanément à la moitié
        collider.height = newInitialHeight;
        collider.center = new Vector3 (collider.center.x, newInitialY, collider.center.z);

        yield return new WaitForSeconds(rollDuration);

        collider.height = initialHeight;
        collider.center = new Vector3(collider.center.x, initialY, collider.center.z);

        isRoll = false; 
    }


    public void Jump()
    {
        if (GourndCheck.getIsGround())
        {
            Debug.Log("Jump");
            GourndCheck.setJumpGround();
            moveRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void Roll()
    {
        Debug.Log("Roll");

        isRoll = true;
        StartCoroutine(AdjustColliderHeight(0.3f));
        moveRigidbody.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);
    }

    private void gestuelTouch()
    {
        foreach (UnityEngine.Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && !hasProcessedTouch)
            {
                float screenHeight = Screen.height;

                if (touch.position.y > screenHeight / 2 || !UIManager.Instance.isPlay())
                {
                    continue;
                }

                fingerDown = touch.position;
                hasProcessedTouch = true;
            }
            else if (touch.phase == TouchPhase.Ended && hasProcessedTouch)
            {
                Vector2 inputVector = (Vector2)(touch.position - fingerDown);

                if (Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
                {
                    if (inputVector.x > 0)
                    {
                        MoveRight();
                    }
                    else
                    {
                        MoveLeft();
                    }
                }
                else
                {
                    if (inputVector.y > 0)
                    {
                        Jump();
                    }
                    else
                    {
                        Roll();
                    }
                }

                hasProcessedTouch = false;
            }
        }
    }

    private void Update()
    {
        float vitesse = MapDistanceToValue(gameObject.transform.position.z);
        Vector3 moveDirection = new Vector3(moveRigidbody.velocity.x, moveRigidbody.velocity.y, Vector3.forward.z * vitesse);


        // Utiliser la vélocité pour le déplacement
        moveRigidbody.velocity = moveDirection;

        animator.SetFloat("speed", Vector3.forward.magnitude);
        animator.SetBool("isRoll", isRoll);
        animator.SetBool("isRunLeft", isRunLeft);
        animator.SetBool("isRunRight", isRunRight);
        // Traiter les événements tactiles ici avec Input.touches

        gestuelTouch();
    }
    float MapDistanceToValue(float distance)
    {
        // Utiliser une fonction linéaire pour ajuster la valeur en fonction de la distance
        float distanceMin = 0f;
        float distanceMax1 = 1000f;
        float distanceMax2 = 10000f;

        float valeurMin = speed;
        float valeurMax1 = 10f;
        float valeurMax2 = 15f;

        float mappedValue;

        if (distance <= distanceMax1)
        {
            mappedValue = Mathf.Lerp(valeurMin, valeurMax1, Mathf.InverseLerp(distanceMin, distanceMax1, distance));
        }
        else if (distance <= distanceMax2)
        {
            mappedValue = Mathf.Lerp(valeurMax1, valeurMax2, Mathf.InverseLerp(distanceMax1, distanceMax2, distance));
        }
        else
        {
            mappedValue = valeurMax2; // Au-delà de distanceMax2, la valeur est constante à 15
        }

        return mappedValue;
    }
}
