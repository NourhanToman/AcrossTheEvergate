using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class AnimationManager : MonoBehaviour
{
    Animator anim;
    int horizontal;
    int vertical;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    void Update()
    {
        setAnimation(InputManager.instance.horizontalInput , InputManager.instance.verticalInput);
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
}
