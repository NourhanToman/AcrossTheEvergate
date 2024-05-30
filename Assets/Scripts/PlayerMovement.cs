using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TargetLockOn lockOn;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 targerDirection = Vector3.zero;
    private Transform cameraTransform;

    [Header("PlayerMovement")]
    [SerializeField] private float moveSpeed = 6f;

    [SerializeField] private float rotationSpeed = 15f;
    private InputManager _inputManager; //Rhods

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        _inputManager = ServiceLocator.Instance.GetService<InputManager>(); //Rhods
    }

    public void handleAllMovement()
    {
        handleMovement();
    }

    public void HandleAllRotations()
    {
        if (_inputManager.isHoldingAttack == true && _inputManager.isLockingOnTarget == true) //Rhods
        {
            handlLockTargetRotation();
        }
        else if (_inputManager.isHoldingAttack == true && _inputManager.isLockingOnTarget == false) //Rhods
        {
            FireRotation();
        }
        else
        {
            handleRotation();
        }
    }

    private void handleMovement()
    {
        moveDirection = cameraTransform.forward * _inputManager.verticalInput; //Rhods
        moveDirection += cameraTransform.right * _inputManager.horizontalInput; //Rhods
        moveDirection.y = 0;
        moveDirection.Normalize();
        moveDirection *= moveSpeed;
        Vector3 movementVelocity = moveDirection;
        rb.velocity = new Vector3(movementVelocity.x, rb.velocity.y, movementVelocity.z);
    } // normal movment handiling

    private void handleRotation()
    {
        targerDirection = cameraTransform.forward * _inputManager.verticalInput; //Rhods
        targerDirection += cameraTransform.right * _inputManager.horizontalInput; //Rhods
        targerDirection.y = 0f;
        targerDirection.Normalize();
        if (targerDirection == Vector3.zero)
        {
            targerDirection = transform.forward;
        }
        Quaternion targetRotation = Quaternion.LookRotation(targerDirection);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
    } // normal rotation handiling

    private void FireRotation()
    {
        targerDirection = cameraTransform.forward;
        //targerDirection += cameraTransform.right;
        //targerDirection.y = 0f;
        targerDirection.Normalize();
        if (targerDirection == Vector3.zero)
        {
            targerDirection = transform.forward;
        }
        Quaternion targetRotation = Quaternion.LookRotation(targerDirection);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, (rotationSpeed / 3) * Time.deltaTime);

        transform.rotation = rotation;
    }

    private void handlLockTargetRotation()
    {
        Vector3 rotationOffset = lockOn.target.transform.position - transform.position;
        rotationOffset.y = 0;
        transform.forward += Vector3.Lerp(transform.forward, rotationOffset, Time.deltaTime * rotationSpeed);
    } // locktarget rotation movement
}