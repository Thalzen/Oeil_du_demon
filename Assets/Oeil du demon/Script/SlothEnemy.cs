using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothEnemy : MonoBehaviour
{
    private int HP;
    private int MAXHP;
    private int castingtime;

    private bool Iscastingfireball;
    private bool IsBlocking;
    [SerializeField]private Transform LeftHand;
    [SerializeField]private Transform RightHand;
    [SerializeField]private EnemySpellCasting _enemySpellCasting;
    

    private void Start()
    {
        StartCoroutine(Pattern());
    }
    
    
    private IEnumerator Pattern()
    { 
        yield return new WaitForSeconds(2f);
       _enemySpellCasting.Fireball();
        yield return new WaitForSeconds(2f);
        StartCoroutine(Pattern());
    }
    
   


}
