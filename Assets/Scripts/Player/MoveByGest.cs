using System;
using System.Collections;
using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class MoveBy : MonoBehaviour
{
    private Vector2 fingerDown;
    private Coroutine moveCoroutine;
    public float speed = 0.5f;
    public float speedChange = 0.5f;
    public Rigidbody moveRigidbody = null;
    private int numerolane = 0;

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
        EnhancedTouch.Touch.onFingerUp += OnFingerUp;
    }

    private void OnDisable()
    {
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
        EnhancedTouch.Touch.onFingerUp -= OnFingerUp;
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
    }

    private void OnFingerDown(EnhancedTouch.Finger finger)
    {
        fingerDown = finger.screenPosition;
    }

    private void OnFingerUp(EnhancedTouch.Finger finger)
    {
        Vector2 inputVector = finger.screenPosition - fingerDown;

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
    }

    public void MoveRight()
    {
        numerolane = Math.Min(numerolane + 2, 2);
        RestartMoveCoroutine(numerolane);
    }

    public void MoveLeft()
    {
        numerolane = Math.Max(numerolane - 2, -2);
        RestartMoveCoroutine(numerolane);
    }

    private void RestartMoveCoroutine(float targetX)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveToX(targetX));
    }

    IEnumerator MoveToX(float targetX)
    {
        float elapsedTime = 0f;
        float initialX = transform.position.x;

        while (elapsedTime < speedChange)
        { 
            elapsedTime += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, elapsedTime / speedChange);
            transform.position = new Vector3(Mathf.Lerp(initialX, targetX, t), transform.position.y, transform.position.z);
            yield return null;
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }

    public void Jump()
    {
        // Action à effectuer lors d'un swipe vers le haut (saut)
        Debug.Log("Jump");
        // Exemple : Appliquer une force vers le haut pour simuler un saut
        //moveRigidbody.velocity = new Vector3(0, speed, 0);
    }

    public void Roll()
    {
        // Action à effectuer lors d'un swipe vers le bas (roulade)
        Debug.Log("Roll");
        // Exemple : Appliquer une force vers le bas pour simuler une roulade
        //moveRigidbody.velocity = new Vector3(0, -speed, 0);
    }

    private void FixedUpdate()
    {
        moveRigidbody.velocity = new Vector3(moveRigidbody.velocity.x
            , moveRigidbody.velocity.y
            , speed);
    }
}
