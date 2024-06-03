using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement movementScript;
    private InputManager _inputManager; //Rhods
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        movementScript = GetComponent<PlayerMovement>();
    }

    private void Start() => _inputManager = ServiceLocator.Instance.GetService<InputManager>(); //Rhods

    private void Update()
    {
        _inputManager.HandelAllInputs(); //Rhods
        movementScript.HandleAllRotations();
        //controlls.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        movementScript.handleAllMovement();
        //locomotion.handleAllMovement();
    }
}
