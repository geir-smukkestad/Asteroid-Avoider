using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float m_forceMagnitude;
    [SerializeField] float m_maxVelocity;

    private Camera m_mainCamera;
    private Rigidbody m_rigidBody;
    private Vector3 m_movementDirection;

    void Start()
    {
        m_mainCamera = Camera.main;
        m_rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = m_mainCamera.ScreenToWorldPoint(touchPos);
            m_movementDirection = transform.position - worldPosition;
            m_movementDirection.z = 0f;
            m_movementDirection.Normalize();
        }
        else
            m_movementDirection = Vector3.zero;
#if false
        if (Touch.activeTouches.Count > 0)
        {
            Debug.Log(Touch.activeTouches[0].screenPosition);
            Vector3 worldPosition = m_mainCamera.ScreenToWorldPoint(Touch.activeTouches[0].screenPosition);
            Debug.Log(worldPosition);
        }
#endif
    }

    private void FixedUpdate() 
    {
         if (m_movementDirection == Vector3.zero)
            return;

        m_rigidBody.AddForce(m_movementDirection * m_forceMagnitude, ForceMode.Force);

        // Prevent velocity from increasing too much during continuous touch input
        m_rigidBody.velocity = Vector3.ClampMagnitude(m_rigidBody.velocity, m_maxVelocity);
    }
}
