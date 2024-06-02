using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Canvas BookCanva;
    [SerializeField] private AutoFlip flipScript;

    PlayerMovement movementScript;
    private InputManager _inputManager; //Rhods
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        movementScript = GetComponent<PlayerMovement>();
        BookCanva.enabled = false;
        flipScript.enabled = false;
    }

    private void Start() => _inputManager = ServiceLocator.Instance.GetService<InputManager>(); //Rhods

    private void Update()
    {
        _inputManager.HandelAllInputs(); //Rhods
        movementScript.HandleAllRotations();

        if(_inputManager.BookCanva)
        {
            BookCanva.enabled = !BookCanva.enabled;
            flipScript.enabled = !flipScript.enabled;
            _inputManager.BookCanva = false;
        }
        //controlls.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        movementScript.handleAllMovement();
        //locomotion.handleAllMovement();
    }
}
