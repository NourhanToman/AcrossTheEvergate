using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraHandling : MonoBehaviour
{
    [SerializeField] TargetLockOn targetLock;
    [SerializeField] CinemachineTargetGroup _CMTargetGroup;
    //[SerializeField] CinemachineVirtualCamera cinemachineTargetLock;
    [SerializeField] CinemachineFreeLook cinemachineTargetLock;
    [SerializeField] CinemachineFreeLook cinemachineFreelock;
    [SerializeField] CinemachineVirtualCamera AimCamera;

    public CinemachineTargetGroup CMtargetGroup
    {
        get => _CMTargetGroup;
        set => _CMTargetGroup = value;
    }

    void Update()
    {
        VirutalCameraLimitation();
        changePriority();
        SwitchCameras();
    }

    void VirutalCameraLimitation()
    {
        if (cinemachineTargetLock.transform.position.y >= 5f)
        {
            cinemachineTargetLock.transform.position = new Vector3(cinemachineTargetLock.transform.position.x, 5f, cinemachineTargetLock.transform.position.z);
        }
        if(cinemachineTargetLock.transform.position.y <= 0)
        {
            cinemachineTargetLock.transform.position = new Vector3(cinemachineTargetLock.transform.position.x, 1f, cinemachineTargetLock.transform.position.z);
        }
    }

    void changePriority()
    {

        cinemachineTargetLock.Priority = 9;
        cinemachineFreelock.Priority = 11;

        if(_CMTargetGroup.m_Targets[0].target != null && targetLock == true) //&& manager.anim.swordState == true)
        {
            cinemachineTargetLock.Priority = 11;
            cinemachineFreelock.Priority = 9;
        }
    }

    void SwitchCameras()
    {
        if (InputManager.instance.isHoldingAttack && AimCamera.gameObject.activeInHierarchy == false)
        {
            AimCamera.gameObject.SetActive(true);
            cinemachineFreelock.gameObject.SetActive(false);
        }
        else if(InputManager.instance.isHoldingAttack == false && cinemachineFreelock.gameObject.activeInHierarchy == false)
        {
            cinemachineFreelock.gameObject.SetActive(true);
            AimCamera.gameObject.SetActive(false);
        }
    }
}
