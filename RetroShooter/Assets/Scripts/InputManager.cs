using System;
using UnityEngine;

public class InputManager : SingletonMonobehaviour<InputManager>
{
    private PlayerInput playerInput;

    public event Action OnJumpStarted;

    protected override void Awake()
    {
        base.Awake();
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();

        playerInput.Player.Jump.started += Jump_started;
    }

    private void OnDisable()
    {
        playerInput.Disable();

        playerInput.Player.Jump.started -= Jump_started;
    }

    private void Jump_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnJumpStarted?.Invoke();
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

    public bool IsFireButtonPressed()
    {
        return playerInput.Player.Fire.inProgress;
    }
}