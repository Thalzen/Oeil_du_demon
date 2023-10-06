using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DumEnemy : MonoBehaviour
{
    [SerializeField]private float HP;
    [SerializeField]private float MAXHP;
    private int castingtime;

    private bool Iscastingfireball;
    private bool IsBlocking;
    [SerializeField]private Transform LeftHand;
    [SerializeField]private Transform RightHand;
    [SerializeField]private EnemyDumSpellCasting _enemyDumSpellCasting;
    [SerializeField]private Image _healthbar;
    [SerializeField]private Toggle FireballBool;
    
    

    private void Start()
    {
        
        //StartCoroutine(StartPattern());
        

    }

    private void OnEnable()
    {
        //PlayerFireBall.DamageDealt += TakingDamage;
        
    }

    private void OnDisable()
    {
        //PlayerFireBall.DamageDealt -= TakingDamage;
        
    }

    private IEnumerator ChoosePattern()
    {
        if (FireballBool.isOn)
        {
            if (HP >= 750f)
            {
                StartCoroutine(PatternAbove75());
            }
            else if (HP >= 500f)
            {
                StartCoroutine(PatternAbove50());
            }
            else if (HP >= 250f)
            {
                StartCoroutine(PatternAbove25());
            }
        }
        

        yield return null;

    }


    private IEnumerator PatternAbove75()
    {
        _enemyDumSpellCasting.Fireball();
        yield return new WaitForSeconds(2f);
        StartCoroutine(ChoosePattern());
    }
    
    private IEnumerator PatternAbove50()
    {
        _enemyDumSpellCasting.Fireball();
        yield return new WaitForSeconds(0.3f);
        _enemyDumSpellCasting.Fireball();
        yield return new WaitForSeconds(2f);
        StartCoroutine(ChoosePattern());
    }
    
    private IEnumerator PatternAbove25()
    {
        _enemyDumSpellCasting.Fireball();
        yield return new WaitForSeconds(0.3f);
        _enemyDumSpellCasting.Fireball();
        yield return new WaitForSeconds(0.3f);
        _enemyDumSpellCasting.Fireball();
        yield return new WaitForSeconds(2f);
        StartCoroutine(ChoosePattern());
    }

    private IEnumerator StartPattern()
    {
        yield return new WaitForSeconds(1f);
        _enemyDumSpellCasting.SpawnShield();
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChoosePattern());
        
    }

    public void Fireballenemyboolstart()
    {

        StartCoroutine(ChoosePattern());

    }

    


    // public void TakingDamage(float damage)
    // {
    //     HP -= damage;
    //     _healthbar.fillAmount = HP / MAXHP;
    //     
    // }
    
    
    
    

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
