using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("COMPONENTS")]
    [SerializeField] private InputManager inputManager;

    [Header("MOVEMENT PARAMETERS")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runningSpeed;

    [Header("JUMP PARAMETERS")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool autoJump;

    [Header("GROUND CHECK PARAMETERS")]
    [SerializeField] private Transform groundCheckOriginTransform;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;

    private new Rigidbody rigidbody;

    private bool isJumpButtonPressed;
    private bool isGrounded;

    private float currentSpeed;

    private Vector3 movement;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputManager.OnJumpStarted += InputManager_OnJumpStarted;
    }

    private void OnDisable()
    {
        inputManager.OnJumpStarted -= InputManager_OnJumpStarted;
    }

    void Update()
    {
        isGrounded = IsPlayerGrounded();

        CalculateCurrentSpeed();
        HandlePlayerInput();
    }


    private void FixedUpdate()
    {
        HandlePlayerMovement();
        HandlePlayerJump();
    }

    private void InputManager_OnJumpStarted()
    {
        if (!autoJump)
        {
            isJumpButtonPressed = true;
        }
    }

    private void HandlePlayerInput()
    {
        if (autoJump)
        {
            isJumpButtonPressed = inputManager.IsJumpButtonPressed();
        }

        movement = transform.forward * inputManager.GetMovementInput().y + 
            transform.right * inputManager.GetMovementInput().x;        
    }

    private void HandlePlayerMovement()
    {
        rigidbody.MovePosition(rigidbody.position + movement * currentSpeed * Time.fixedDeltaTime);
    }

    private void HandlePlayerJump()
    {
        if (isGrounded && isJumpButtonPressed)
        {
            isJumpButtonPressed = false;
            rigidbody.AddForce(Vector3.up * jumpHeight, 
                ForceMode.VelocityChange);
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

    private bool IsPlayerGrounded()
    {
        return Physics.Raycast(groundCheckOriginTransform.position,
                    -Vector3.up, groundCheckDistance, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Ray ray = new Ray(groundCheckOriginTransform.position, -Vector3.up);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray.origin, ray.direction.normalized * groundCheckDistance + ray.origin);
    }
}