using System.Collections;
using System;
using UnityEngine;

public class comparar : IComparer
{
    private Transform comparerTarget;

    public comparar(Transform compTransform)
    {
         comparerTarget = compTransform;
    }

    public int Compare(object x, object y)
    {
        Collider xColider = x as Collider;
        Collider yColider = y as Collider;

        Vector3 offset = xColider.transform.position - comparerTarget.position;
        float xDistance = offset.sqrMagnitude;

        offset = yColider.transform.position - comparerTarget.position;
        float yDistance = offset.sqrMagnitude;

        return xDistance.CompareTo(yDistance);
    }
}
