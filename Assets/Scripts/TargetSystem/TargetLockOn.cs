using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetLockOn : MonoBehaviour
{
    PlayerManager manager;
    public cameraHandling CM;

    [SerializeField] Transform _TargetToLockOn;
    [SerializeField] GameObject lockOnCanves;
    [SerializeField] Collider[] overlapColiders;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask checkLayer;
    [SerializeField] Vector3 boxSize;
    [Header("Target System")]
    public int targetCounter = 0;
    public float TargetLockOnCursorOffset;

    public Transform target
    {
        get => _TargetToLockOn;
        //set => _TargetToLockOn = value;
        private set { }
    }


    private void Awake()
    {
        manager = GetComponent<PlayerManager>();
    }
    private void Start()
    {
        StartCoroutine(Sorting());
    }
    private void FixedUpdate()
    {
        getTarget();
        targetCanves();
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    } // draw phere gizmo on the player

    void getTarget()
    {
        CM.CMtargetGroup.m_Targets[0].target = null;
        overlapColiders = Physics.OverlapSphere(transform.position, checkRadius, checkLayer);

        foreach (Collider col in overlapColiders)
        {

            if(targetCounter >= overlapColiders.Length)
            {
               targetCounter = 0;
            }

            target = overlapColiders[0].transform;
            CM.CMtargetGroup.m_Targets[0].target = target;
            lockOnCanves.transform.position = Camera.main.WorldToScreenPoint(new Vector3(target.position.x, target.position.y + TargetLockOnCursorOffset , target.position.z));
        }


    } //set shpere overlap colider to check the map and get the coliders there and then get the closest target and then lock it to Main target

    void targetCanves()
    {
        lockOnCanves.SetActive(false);

        if(InputManager.instance.isLockingOnTarget == true && CM.CMtargetGroup.m_Targets[0].target != null)
        {
            lockOnCanves.SetActive(true);
        }
    }

    IEnumerator Sorting()
    {
        yield return new WaitForSeconds(10);
        Array.Sort(overlapColiders, new comparar(transform));

    }

    public void changeTarget()
    {
        targetCounter += 1;
    }
}
