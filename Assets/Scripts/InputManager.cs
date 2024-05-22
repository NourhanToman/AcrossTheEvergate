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
    public bool isLockingOnTarget;
    public bool canAttackAgain;
    public bool canMove;
    public bool playerAttacked;
    public bool playerInteracted;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        canAttackAgain = true;
        isHoldingWeapon = false;
        canMove = true;
        playerAttacked = false;
        playerInteracted = false;
    }

    private void OnEnable()
    {
        if(action == null)
        {
            action = new InputActions();
            action.PlayerLocomoation.Movement.performed += i => moveInput = i.ReadValue<Vector2>();
            action.PlayerLocomoation.DrawWeapon.performed += i => HandleWeaponDraw();
            action.PlayerLocomoation.Attack.performed += i => HandlePlayerAttack();
            action.PlayerLocomoation.Attack.canceled += i => PlayerReleaseAttack();
            action.PlayerLocomoation.TargetLock.performed += i => LockOnTarget();
            action.PlayerLocomoation.Interact.performed += i => Interact();
            action.PlayerLocomoation.Interact.canceled += i => CancelInteract();
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
        if(canAttackAgain == true)
        {
            verticalInput = moveInput.y;
            horizontalInput = moveInput.x;
        }
        else
        {
            verticalInput = 0f; horizontalInput = 0f;
        }

    }
    public void HandlePlayerAttack()
    {
        if(isHoldingAttack == false && isHoldingWeapon == true && canAttackAgain == true)
        {
            isHoldingAttack = true;
            playerAttacked = true;
        }
    }
    public void PlayerReleaseAttack()
    {
        isHoldingAttack = false;
        if (canAttackAgain == true && playerAttacked == true)
        {
            StartCoroutine(WaitBeforeAttackAgain());
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
    void LockOnTarget()
    {
        if(isLockingOnTarget == false && isHoldingWeapon == true)
        {
            isLockingOnTarget = true;
        }
        else
        {
            isLockingOnTarget = false;
        }
    }
    IEnumerator WaitBeforeAttackAgain()
    {
        canAttackAgain = false;
        yield return new WaitForSeconds(0.55f);
        playerAttacked= false;
        canAttackAgain = true;
    }

    void Interact()
    {
        playerInteracted = true;
    }

    void CancelInteract()
    {
        playerInteracted = false;
    }
}
