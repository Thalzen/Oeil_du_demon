using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] float InputThreshold = 0.1f;
    public float HP = 30;
    public float MAXHP = 30;
    public Image _healthbar;
    private bool isPulsed;

    private void Start()
    {
        
    }


    private void OnEnable()
    {
        EnemyFireBall.PlayerShieldDamage += TakingDamage;
    }

    private void OnDisable()
    {
        EnemyFireBall.PlayerShieldDamage -= TakingDamage;
    }

    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), InputHelpers.Button.Trigger, out bool isPressed, InputThreshold);
        if (isPressed && !isPulsed)
        {
            isPulsed = true;
            StartCoroutine(Pulse());
        }
    }

    public void TakingDamage(float damage)
    {
        if(!isPulsed)
        {
            HP -= damage;
            _healthbar.fillAmount = HP / MAXHP;
        }

        if (HP == 0f)
        {
            gameObject.SetActive(false);
        }
        
    }
    
    private IEnumerator Pulse()
    {
        yield return new WaitForSeconds(3f);
        isPulsed = false;
    }

}
