using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private float walkingSpeed = 7.5f;
    [SerializeField] private float runningSpeed = 11.5f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private Camera playerCamera = new Camera();
    [SerializeField] private float lookXLimit = 45.0f;

    public static float MouseSensitivity { get; set; } = 2.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    public bool CanMove { get; set; } = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (PlayingUI.IsEnabled)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool isRunning = Input.GetButton("Sprint");
            float curSpeedX = CanMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = CanMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButtonDown("Jump") && CanMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            if (CanMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * MouseSensitivity;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0);
            }
        }
    }
}