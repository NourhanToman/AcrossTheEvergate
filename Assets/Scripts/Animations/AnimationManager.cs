using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class AnimationManager : MonoBehaviour
{
    Rigidbody rb;
    CollisionDetection col;
    Animator anim;
    int horizontal;
    int vertical;
    int holdingBow;
    int HoldingFire;
    int velocityY;
    int jumping;
    int Grounded;
    [SerializeField] Transform Bow, handPos, backPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody>();
        col = GetComponentInParent<CollisionDetection>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
        holdingBow = Animator.StringToHash("HoldingBow");
        HoldingFire = Animator.StringToHash("HoldingFire");
        velocityY = Animator.StringToHash("VelocityY");
        jumping = Animator.StringToHash("Jump");
        Grounded = Animator.StringToHash("Grounded");
    }

    void Update()
    {
        setAnimation(InputManager.instance.horizontalInput , InputManager.instance.verticalInput);
        anim.SetBool(holdingBow, InputManager.instance.isHoldingWeapon);
        anim.SetBool(HoldingFire, InputManager.instance.isHoldingAttack);
        anim.SetFloat(velocityY, rb.velocity.y);
        anim.SetBool(jumping, InputManager.instance.isJumping);
        anim.SetBool(Grounded, col.Grounded);
    }

    public void setAnimation(float horizontalInput, float verticalInput)
    {
        float snappedHorizontal;
        float snappedVertical;

        #region horizontal
        if (horizontalInput > 0)
        {
            snappedHorizontal = 1;
        }
        else if (horizontalInput < 0)
        {
            snappedHorizontal = -1f;
        }
        else
        {
            snappedHorizontal = 0f;
        }
        #endregion

        #region vertical
        if (verticalInput > 0)
        {
            snappedVertical = 1f;
        }
        else if (verticalInput < 0)
        {
            snappedVertical = -1f;
        }
        else
        {
            snappedVertical = 0f;
        }
        #endregion

        anim.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        anim.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);

    } //control character animation movement

    public void draw()
    {
        Bow.transform.SetParent(handPos);
        Bow.position = handPos.position;
        Bow.rotation = handPos.rotation;
    } // makes the hand parent of the sword when draw animation playes

    public void heath()
    {
        Bow.transform.SetParent(backPos);
        Bow.position = backPos.position;
        Bow.rotation = backPos.rotation;
    } // remove the hand parent of the sword when heath animation playes
}
