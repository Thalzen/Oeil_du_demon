using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class EnemyShield : MonoBehaviour
{
    public float HP = 10;
    public float MAXHP = 10;
    public Image _healthbar;
    private bool isPulsed;

    private void Start()
    {
        
    }


    private void OnEnable()
    {
        PlayerFireBall.EnemyShieldDamage += TakingDamage;
        PlayerElecBall.EnemyShieldDamage += TakingDamage;
    }

    private void OnDisable()
    {
        PlayerFireBall.EnemyShieldDamage -= TakingDamage;
        PlayerElecBall.EnemyShieldDamage -= TakingDamage;
    }
    
    public void TakingDamage(float damage)
    {
        if(!isPulsed)
        {
            HP -= damage;
            _healthbar.fillAmount = HP / MAXHP;
        }

        if (HP <= 0f)
        {
            gameObject.SetActive(false);
        }
        
    }

}
