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

    private void Start()
    {
        chargeEffectActivated = false;
        shootEffectActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.instance.isHoldingAttack == true && chargeEffectActivated == false)
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
        else if (InputManager.instance.isHoldingAttack == false && shootEffectActivated == false && InputManager.instance.canAttackAgain == false)
        {
            ChargeEffect.Stop();
            ChargeEffect2.Stop();
            chargeEffectActivated = false;
            GameObject arrowPrefab = Instantiate(arrow, new Vector3(transform.position.x , yPos , transform.position.z), Quaternion.identity);
            arrowPrefab.transform.rotation = this.transform.rotation;
            ShootEffect.Play();
            shootEffectActivated = true;
        }
    }
}
