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
    private AudioManager _AudioManager;

    private void Start()
    {
        chargeEffectActivated = false;
        shootEffectActivated = false;
        _inputManager = ServiceLocator.Instance.GetService<InputManager>(); //Rhods
        _AudioManager = ServiceLocator.Instance.GetService<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputManager.isHoldingAttack == true && chargeEffectActivated == false) //Rhods
        {
            ChargeEffect.Play();
            ChargeEffect2.Play();
            _AudioManager.PlaySFX("ChargeArrow");
            StartCoroutine(PlayLoopArrowSound());
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
            _AudioManager.StopSFX("ChargeArrow");
            _AudioManager.StopSFX("LoopArrow");
            chargeEffectActivated = false;
            GameObject arrowPrefab = Instantiate(arrow, ArrowPos.position, Quaternion.identity);
            arrowPrefab.transform.rotation = this.transform.rotation;
            ShootEffect.Play();
            _AudioManager.PlaySFX("FireArrow");
            shootEffectActivated = true;
            this.transform.rotation = new Quaternion(0, this.transform.rotation.y, 0, this.transform.rotation.w);
        }
    }

    IEnumerator PlayLoopArrowSound()
    {
        yield return new WaitForSeconds(3);
        if(_inputManager.isHoldingAttack == true && chargeEffectActivated == true)
        {
            _AudioManager.PlaySFX("LoopArrow");
        }
    }
}
