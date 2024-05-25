using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShaderEffect : MonoBehaviour
{
    [SerializeField] private float dissolveAmout;
    [SerializeField] private float dissolveSpeed;
    [SerializeField] private float maxValue;
    [SerializeField] private float minValue;
    [SerializeField] private float currentDissolveValue;
    [SerializeField] private float refVelocity;
    [SerializeField] private string dissolveReferance;

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.isHoldingWeapon)
        {
            currentDissolveValue = Mathf.SmoothDamp(currentDissolveValue, minValue, ref refVelocity, dissolveSpeed);
        }
        else
        {
            currentDissolveValue = Mathf.SmoothDamp(currentDissolveValue, maxValue, ref refVelocity, dissolveSpeed);
        }

        Shader.SetGlobalFloat(dissolveReferance, currentDissolveValue);
    }

}
