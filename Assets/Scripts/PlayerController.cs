using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    Vector2 moveInput;
    Vector2 lookInput;
    [SerializeField] Camera playerCamera;
    [SerializeField] float cameraDistance = 1f;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float sensitivity = .4f;
    [SerializeField] float maxCameraAngle = 90f;
    [SerializeField] float minCameraAngle = -10f;
    float pitch = 0f;
    float yaw = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveInput = input.actions["Move"].ReadValue<Vector2>();
        lookInput = input.actions["Look"].ReadValue<Vector2>();

        Vector3 camForward = playerCamera.transform.forward;
        Vector3 camRight = playerCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 posChange = camRight * moveInput.x + camForward * moveInput.y;
        transform.position += posChange * moveSpeed;

        yaw += lookInput.x * sensitivity;
        transform.rotation = Quaternion.Euler(0, yaw, 0);

        MoveCamera();
    }
    void MoveCamera()
    {
        pitch += lookInput.y * sensitivity; 
        pitch = Mathf.Clamp(pitch, minCameraAngle, maxCameraAngle);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 offset = rotation * new Vector3(0, 0, -cameraDistance);
        playerCamera.transform.position = transform.position + offset;
        playerCamera.transform.LookAt(transform.position);

    }
}