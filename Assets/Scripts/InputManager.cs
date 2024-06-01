using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //should i add static in below and that awake template?
    private InputActions action;
    public static InputManager instance;
    private Vector2 moveInput;
    private Vector2 rotationInput;
    public bool isHoldingWeapon;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalRotationInput;
    public float verticalRotationInput;
    public bool isHoldingAttack;
    public bool isLockingOnTarget;
    public bool canAttackAgain;
    public bool canMove;
    public bool playerAttacked;
    public bool playerInteracted;
    public bool isJumping;
    public bool canJump;
    public bool isRightFlip;
    public bool isLeftFlip;

    //public bool canDrawWeapon;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ServiceLocator.Instance.RegisterService(this);//Rhods
        }
    }

    private void Start()
    {
        canAttackAgain = true;
        isHoldingWeapon = false;
        canMove = true;
        playerAttacked = false;
        playerInteracted = false;
        isJumping = false;
        canJump = true;
       // canDrawWeapon = false;
    }

    private void OnEnable()
    {
        if (action == null)
        {
            action = new InputActions();
            action.PlayerLocomoation.Movement.performed += i => moveInput = i.ReadValue<Vector2>();
            action.PlayerLocomoation.Look.started += i => rotationInput = i.ReadValue<Vector2>();
            action.PlayerLocomoation.Look.canceled += i => rotationInput  = Vector2.zero;
            action.PlayerLocomoation.DrawWeapon.performed += i => HandleWeaponDraw();
            action.PlayerLocomoation.Attack.performed += i => HandlePlayerAttack();
            action.PlayerLocomoation.Attack.canceled += i => PlayerReleaseAttack();
            action.PlayerLocomoation.TargetLock.performed += i => LockOnTarget();
            action.PlayerLocomoation.Interact.performed += i => Interact();
            action.PlayerLocomoation.Interact.canceled += i => CancelInteract();
            action.PlayerLocomoation.Jump.performed += i => playerJump();
            action.PlayerLocomoation.FlipPageRight.performed += i => RightFlip();
            action.PlayerLocomoation.FlipPageRight.canceled += i => CancelRightFlip();
            action.PlayerLocomoation.FlipPageLeft.performed += i => LeftFlip();
            action.PlayerLocomoation.FlipPageLeft.canceled += i => CancelLeftFlip();

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
        handleRotationInput();
    }


    public void handleMovementInput()
    {
        if (canAttackAgain == true)
        {
            verticalInput = moveInput.y;
            horizontalInput = moveInput.x;
        }
        else
        {
            verticalInput = 0f; horizontalInput = 0f;
        }
    }

    public void handleRotationInput()
    {
        if (canAttackAgain == true)
        {
            verticalRotationInput = rotationInput.y ;
            horizontalRotationInput = rotationInput.x ;
        }
        else
        {
            verticalRotationInput = 0f; horizontalRotationInput = 0f;
        }
    }

    public void HandlePlayerAttack()
    {
        if (isHoldingAttack == false && isHoldingWeapon == true && canAttackAgain == true)
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

    private void HandleWeaponDraw()
    {
        if ( !isHoldingWeapon)
        {
            isHoldingWeapon = true;
        }
        else {
            isHoldingWeapon = false;
        }
    }

    private void LockOnTarget()
    {
        if (isLockingOnTarget == false && isHoldingWeapon == true)
        {
            isLockingOnTarget = true;
        }
        else
        {
            isLockingOnTarget = false;
        }
    }

    private void playerJump()
    {
        if (isJumping == false && canJump == true)
        {
            isJumping = true;
            canJump = false;
        }
    }

    private IEnumerator WaitBeforeAttackAgain()
    {
        canAttackAgain = false;
        yield return new WaitForSeconds(0.55f);
        playerAttacked = false;
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

    void RightFlip()
    {
        isRightFlip = true;
    }

    void CancelRightFlip()
    {
        isRightFlip = false;
    }
    void LeftFlip()
    {
        isLeftFlip = true;
    }
    void CancelLeftFlip()
    {
        isLeftFlip = false;
    }
}
