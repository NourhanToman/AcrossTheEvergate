using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement movementScript;
    private void Awake()
    {
        movementScript = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        InputManager.instance.HandelAllInputs();
        //controlls.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        movementScript.handleAllMovement();
        //locomotion.handleAllMovement();
    }
}
