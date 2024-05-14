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
    public bool isHoldingAttack;
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
            action.PlayerLocomoation.Attack.performed += i => HandlePlayerAttack();
            action.PlayerLocomoation.Attack.canceled += i => HandlePlayerAttack();
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


    public void HandlePlayerAttack()
    {
        if(isHoldingAttack == false && isHoldingWeapon == true)
        {
            isHoldingAttack = true;
        }
        else
        {
            isHoldingAttack = false;
        }
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
