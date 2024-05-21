using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    CollisionDetection col;
    Rigidbody rb;
    [SerializeField] private float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CollisionDetection>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.instance.isJumping == true && col.Grounded == true)
        {
            rb.velocity = Vector3.up * jumpForce;
            //InputManager.instance.isJumping = false;
        }
    }
}
