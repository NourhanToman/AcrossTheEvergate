using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    InputActions action;
    public static InputManager instance;
    Vector2 moveInput;
    public bool isHoldingWeapon;
    public float horizontalInput;
    public float verticalInput;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        isHoldingWeapon = false;
    }

    private void OnEnable()
    {
        if(action == null)
        {
            action = new InputActions();
            action.PlayerLocomoation.Movement.performed += i => moveInput = i.ReadValue<Vector2>();
            action.PlayerLocomoation.DrawWeapon.performed += i => HandleWeaponDraw();
        }
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    public void HandelAllInputs()
    {
        handleMovementInput();
    }

    public void handleMovementInput()
    {
        verticalInput = moveInput.y;
        horizontalInput = moveInput.x;
    }

    void HandleWeaponDraw()
    {
        if(isHoldingWeapon == false)
        {
            isHoldingWeapon=true;
        }
        else
        {
            isHoldingWeapon = false;
        }
    }
}
