using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement movementScript;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        movementScript = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        InputManager.instance.HandelAllInputs();
        movementScript.HandleAllRotations();
        //controlls.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        movementScript.handleAllMovement();
        //locomotion.handleAllMovement();
    }
}
