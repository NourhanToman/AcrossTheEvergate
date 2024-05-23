using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;
    [SerializeField] GameObject hitEffect;

    private void Start()
    {
        StartCoroutine(distroyArrowAfterTime());
    }
    void Update()
    {
        transform.position += transform.forward * arrowSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(hitEffect, collision.GetContact(0).point, Quaternion.identity);
        Destroy(this.gameObject);
    }

    IEnumerator distroyArrowAfterTime()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);

    }
}
