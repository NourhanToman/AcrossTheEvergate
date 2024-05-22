using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool Grounded;
    [SerializeField] float radius;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector3 CheckPos;
    private void FixedUpdate()
    {
        Grounded = Physics.CheckSphere(transform.position + CheckPos, radius, groundLayer);
        if(Grounded == true && InputManager.instance.isJumping == true)
        {
            InputManager.instance.isJumping = false;
            InputManager.instance.canJump = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + CheckPos, radius);
    }
}
