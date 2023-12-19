using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using System.Diagnostics;

public class MyPlayer : MonoBehaviour
{

   // public int maxLife = 2;
   // public Rigidbody moveBody = null;
   // public GroundCheck groundCheck = null;
   // public Animator animator = null;

    public int DistanceParcouru { get; set; }
    public int CurrentLife { get; private set; }

    private Vector2 FingerDown;

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
        FingerDown = finger.screenPosition;
    }

    private void OnFingerUp(EnhancedTouch.Finger finger)
    {
        Vector2 inputVector =  finger.screenPosition - FingerDown;
        if (Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
        {
            if (inputVector.x > 0)
            {
                RightSwipe();
            }
            else
            {
                LeftSwipe();
            }
        }
        else
        {
            if (inputVector.y > 0)
            {
                UpSwipe();
            }
            else
            {
                DownSwipe();
            }
        }
    }

    public void RightSwipe()
    {
        Debug.Log($"Right :Touch screen pos: {touch.screenPosition}");
    }

    public void LeftSwipe()
    {
        Debug.Log($"Left :Touch screen pos: {touch.screenPosition}");
    }

    public void UpSwipe()
    {
        Debug.Log($"Up :Touch screen pos: {touch.screenPosition}");
    }

    public void DownSwipe()
    {
        Debug.Log($"Down :Touch screen pos: {touch.screenPosition}");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
