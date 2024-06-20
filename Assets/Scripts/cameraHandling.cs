using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraHandling : MonoBehaviour
{
    [SerializeField] CinemachineTargetGroup _CMTargetGroup;
    [SerializeField] CinemachineVirtualCamera cinemachineTargetLock;
    [SerializeField] CinemachineFreeLook cinemachineFreelock;
    [SerializeField] CinemachineVirtualCamera AimCamera;
    [SerializeField] CinemachineVirtualCamera AimCameraWithLock;
    [SerializeField] GameObject CrossHair;

    private InputManager _inputManager; //Rhods

    private void Start() => _inputManager = ServiceLocator.Instance.GetService<InputManager>(); //Rhods

    public CinemachineTargetGroup CMtargetGroup
    {
        get => _CMTargetGroup;
        set => _CMTargetGroup = value;
    }

    void Update()
    {
        //VirutalCameraLimitation();
        changePriority();
        SwitchCameras();
    }
    /*void VirutalCameraLimitation()
    {
        if (cinemachineTargetLock.transform.position.y >= 5f)
        {
            cinemachineTargetLock.transform.position = new Vector3(cinemachineTargetLock.transform.position.x, 5f, cinemachineTargetLock.transform.position.z);
        }
        if(cinemachineTargetLock.transform.position.y <= 0)
        {
            cinemachineTargetLock.transform.position = new Vector3(cinemachineTargetLock.transform.position.x, 1f, cinemachineTargetLock.transform.position.z);
        }
    }*/
    void changePriority()
    {
        if(_CMTargetGroup.m_Targets[0].target != null && _inputManager.isLockingOnTarget == true) //&& manager.anim.swordState == true) //Rhods
        {
            cinemachineTargetLock.gameObject.SetActive(true);
        }
        else
        {
            cinemachineTargetLock.gameObject.SetActive(false);
        }
    }
    void SwitchCameras()
    {
        if (_inputManager.isHoldingAttack && AimCamera.gameObject.activeInHierarchy == false && _inputManager.isLockingOnTarget == false) //Rhods
        {
            AimCamera.gameObject.SetActive(true);
            AimCameraWithLock.gameObject.SetActive(false);
            cinemachineFreelock.gameObject.SetActive(false);
        }
        else if(_inputManager.isHoldingAttack == false && cinemachineFreelock.gameObject.activeInHierarchy == false) //Rhods
        {
            cinemachineFreelock.gameObject.SetActive(true);
            AimCameraWithLock.gameObject.SetActive(false);
            AimCamera.gameObject.SetActive(false);
        }
        else if(_inputManager.isHoldingAttack && _inputManager.isLockingOnTarget == true) //Rhods
        {
            AimCameraWithLock.gameObject.SetActive(true);
            AimCamera.gameObject.SetActive(false);
            cinemachineFreelock.gameObject.SetActive(false);
        }

        if(_inputManager.isHoldingAttack == true && _inputManager.isLockingOnTarget == false) //Rhods
        {
            CrossHair.gameObject.SetActive(true);
        }
        else
        {
            CrossHair.gameObject.SetActive(false);
        }
    }
    IEnumerator SwitchToFreeLook()
    {
        yield return new WaitForSeconds(0.5f);
        cinemachineFreelock.gameObject.SetActive(true);
        AimCameraWithLock.gameObject.SetActive(false);
        AimCamera.gameObject.SetActive(false);
    }
}
