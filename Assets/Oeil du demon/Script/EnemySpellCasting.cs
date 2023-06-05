using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemySpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject Enemyfireball;
    public Transform[] EnemyTargetPos;
    private GameObject spawnedfireball;
    [SerializeField] private GameObject EnemyShield;
    

    private void Start()
    {
        
    }


    //targetpos[0] = Enemypos
    //targetpos[1] = playerpos
    public void Fireball()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position, Quaternion.identity);
        spawnedfireball.GetComponent<EnemyFireBall>().StartCoroutine(spawnedfireball.GetComponent<EnemyFireBall>().enemyfireballmove(EnemyTargetPos[0],EnemyTargetPos[1]));

    }

    public void SpawnShield()
    {
        EnemyShield enemyShield = EnemyShield.GetComponent<EnemyShield>();
        EnemyShield.SetActive(true);
        enemyShield.HP = 30f;
        enemyShield._healthbar.fillAmount = enemyShield.HP / enemyShield.MAXHP;
       
    }

}
