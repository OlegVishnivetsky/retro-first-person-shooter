using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("COMPONENTS")]
    [SerializeField] private InputManager inputManager;

    [Header("MOVEMENT PARAMETERS")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runningSpeed;

    [Header("JUMP PARAMETERS")]
    [SerializeField] private float jumpForce;

    private float currentSpeed;
    private float gravityValue;

    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool groundedPlayer;

    private void Awake()
    {
        gravityValue = Physics.gravity.y;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CalculateCurrentSpeed();
        HandlePlayerGravity();
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {    
        Vector3 movement = transform.forward * inputManager.GetMovementInput().y + 
            transform.right * inputManager.GetMovementInput().x;

        controller.Move(movement * Time.deltaTime * currentSpeed);
    }

    private void HandlePlayerGravity()
    {
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        HandlePlayerJump();

        if (controller.isGrounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = 0.5f;
        }
    }

    private void HandlePlayerJump()
    {
        if (inputManager.IsJumpButtonPressed() && controller.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * Mathf.Abs(gravityValue));
        }
    }

    private void CalculateCurrentSpeed()
    {
        if (inputManager.IsRunningButtonPressed())
        {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
    }
}