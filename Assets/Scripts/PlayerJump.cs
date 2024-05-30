using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    CollisionDetection col;
    Rigidbody rb;
    [SerializeField] private float jumpForce;
    private InputManager _inputManager; //Rhods
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CollisionDetection>();
        rb = GetComponent<Rigidbody>();
        _inputManager = ServiceLocator.Instance.GetService<InputManager>(); //Rhods
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputManager.isJumping == true && col.Grounded == true) //Rhods
        {
            rb.velocity = Vector3.up * jumpForce;
            //InputManager.instance.isJumping = false;
        }
    }
}
