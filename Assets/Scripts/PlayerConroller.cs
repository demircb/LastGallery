using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f; // Reduced movement speed
    public float rotationSpeed = 2f; // Mouse rotation speed

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hide cursor
    }

    void Update()
    {
        // Handle WASD movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount);

        // Handle mouse look
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation
        transform.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector2.left * mouseY); // Apply vertical rotation

        // Debug logs
        Debug.Log($"Mouse X: {mouseX}, Mouse Y: {mouseY}");
        Debug.Log($"X Rotation: {xRotation}");
    }
}
