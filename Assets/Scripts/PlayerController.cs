using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    PlayerInput input;
    Vector2 moveInput;
    public Collider positionToVaultTo;
    [SerializeField] Camera playerCamera;

    [SerializeField] float moveSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        input = GetComponent<PlayerInput>();
        input.actions["WindowVault"].performed += ctx => ActivateWindowVault();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveInput = input.actions["Move"].ReadValue<Vector2>();

        Vector3 camForward = playerCamera.transform.forward;
        Vector3 camRight = playerCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 posChange = camRight * moveInput.x + camForward * moveInput.y;
        transform.position += posChange * moveSpeed;

        transform.rotation = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0);

    }

    void ActivateWindowVault()
    {
        if(positionToVaultTo != null)
        {
            transform.position = positionToVaultTo.bounds.center;
        }
    }
}