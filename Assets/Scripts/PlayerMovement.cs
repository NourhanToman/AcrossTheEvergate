using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] TargetLockOn lockOn;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 targerDirection = Vector3.zero;
    private Transform cameraTransform;

    [Header("PlayerMovement")]
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float rotationSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }
    public void handleAllMovement()
    {
        handleMovement();
    }
    public void HandleAllRotations()
    {
        if (InputManager.instance.isHoldingAttack == true && InputManager.instance.isLockingOnTarget == true)
        {
            handlLockTargetRotation();
        }
        else if (InputManager.instance.isHoldingAttack == true && InputManager.instance.isLockingOnTarget == false)
        {
            FireRotation();
        }
        else
        {
            handleRotation();
        }
    }
    void handleMovement()
    {
        moveDirection = cameraTransform.forward * InputManager.instance.verticalInput;
        moveDirection += cameraTransform.right * InputManager.instance.horizontalInput;
        moveDirection.y = 0;
        moveDirection.Normalize();
        moveDirection *= moveSpeed;
        Vector3 movementVelocity = moveDirection;
        rb.velocity = new Vector3(movementVelocity.x , rb.velocity.y , movementVelocity.z);
    } // normal movment handiling
    void handleRotation()
    {
        targerDirection = cameraTransform.forward * InputManager.instance.verticalInput;
        targerDirection += cameraTransform.right * InputManager.instance.horizontalInput;
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
    void FireRotation()
    {
        if (InputManager.instance.isHoldingAttack == true)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraTransform.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        }
    }
    private void handlLockTargetRotation()
    {
        Vector3 rotationOffset = lockOn.target.transform.position - transform.position;
        rotationOffset.y = 0;
        transform.forward += Vector3.Lerp(transform.forward, rotationOffset, Time.deltaTime * rotationSpeed);
    } // locktarget rotation movement


}
