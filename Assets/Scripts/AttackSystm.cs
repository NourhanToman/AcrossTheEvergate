using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystm : MonoBehaviour
{
    [SerializeField] ParticleSystem ChargeEffect;
    [SerializeField] ParticleSystem ChargeEffect2;
    [SerializeField] ParticleSystem ShootEffect;
    [SerializeField] Transform ArrowPos;
    [SerializeField] GameObject arrow;
    [SerializeField] float yPos;
    private bool chargeEffectActivated;
    private bool shootEffectActivated;
    private InputManager _inputManager; //Rhods

    private void Start()
    {
        chargeEffectActivated = false;
        shootEffectActivated = false;
        _inputManager = ServiceLocator.Instance.GetService<InputManager>(); //Rhods
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputManager.isHoldingAttack == true && chargeEffectActivated == false) //Rhods
        {
            ChargeEffect.Play();
            ChargeEffect2.Play();
            chargeEffectActivated = true;
            if(shootEffectActivated == true)
            {
                ShootEffect.Stop();
                shootEffectActivated = false;
            }
        }
        else if (_inputManager.isHoldingAttack == false && shootEffectActivated == false && _inputManager.canAttackAgain == false) //Rhods
        {
            ChargeEffect.Stop();
            ChargeEffect2.Stop();
            chargeEffectActivated = false;
            GameObject arrowPrefab = Instantiate(arrow, ArrowPos.position, Quaternion.identity);
            arrowPrefab.transform.rotation = this.transform.rotation;
            ShootEffect.Play();
            shootEffectActivated = true;
            this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, this.transform.rotation.w);
        }
    }

    IEnumerator resetRotation()
    {
        yield return new WaitForSeconds(0.6f);
        
    }
}
