using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;
    void Update()
    {
        transform.position += transform.forward * arrowSpeed * Time.deltaTime;
    }
}
