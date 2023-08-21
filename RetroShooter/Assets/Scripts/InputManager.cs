using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();       
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public Vector2 GetMovementInput()
    {
        return playerInput.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerInput.Player.Look.ReadValue<Vector2>();
    }

    public bool IsRunningButtonPressed()
    {
        return playerInput.Player.Running.inProgress;
    }

    public bool IsJumpButtonPressed()
    {
        return playerInput.Player.Jump.inProgress;
    }
}