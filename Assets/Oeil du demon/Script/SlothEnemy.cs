using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlothEnemy : MonoBehaviour
{
    [SerializeField]private float HP;
    [SerializeField]private float MAXHP;
    private int castingtime;

    private bool Iscastingfireball;
    private bool IsBlocking;
    [SerializeField]private Transform LeftHand;
    [SerializeField]private Transform RightHand;
    [SerializeField]private EnemySpellCasting _enemySpellCasting;
    [SerializeField] private Image _healthbar;
    

    private void Start()
    {

        StartCoroutine(Pattern());
    }

    private void OnEnable()
    {
        PlayerFireBall.DamageDealt += TakingDamage;
    }

    private void OnDisable()
    {
        PlayerFireBall.DamageDealt -= TakingDamage;
    }


    private IEnumerator Pattern()
    { 
        yield return new WaitForSeconds(1f);
       _enemySpellCasting.Fireball();
        yield return new WaitForSeconds(3f);
        _enemySpellCasting.SpawnShield();
        StartCoroutine(Pattern());
    }

    


    public void TakingDamage(float damage)
    {
        HP -= damage;
        _healthbar.fillAmount = HP / MAXHP;
        
    }
    
    
    
    

    // private IEnumerator shotgun()
    // {
    //     for (int i = 1; i < 30f; i++)
    //     {
    //         StartCoroutine(Pattern());
    //         yield return new WaitForSeconds(0.1f);
    //     }
    // }
    //
   


}
