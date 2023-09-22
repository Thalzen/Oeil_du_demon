using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemySpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject Enemyfireball;
    public Transform[] playertargetpos;
    public Transform enemypos;
    private GameObject spawnedfireball;
    [SerializeField] private GameObject EnemyShield;
    private bool _shieldRefreshing = false;
    

    
    private void OnEnable()
    {
        global::EnemyShield.EnemyShieldCheck += RefreshShield;
    }
    
    private void OnDisable()
    {
        global::EnemyShield.EnemyShieldCheck -= RefreshShield;
    }


    //targetpos[0] = Enemypos
    //targetpos[1] = playerpos
    public void Fireball()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position, Quaternion.identity);
        spawnedfireball.GetComponent<EnemyFireBall>().StartCoroutine(spawnedfireball.GetComponent<EnemyFireBall>().enemyfireballmove(enemypos,playertargetpos));

    }

    public void SpawnShield()
    {
        EnemyShield enemyShield = EnemyShield.GetComponent<EnemyShield>();
        EnemyShield.SetActive(true);
        enemyShield.HP = 10f;
        enemyShield._healthbar.fillAmount = enemyShield.HP / enemyShield.MAXHP;
        enemyShield.gameObject.GetComponent<Renderer>().material.SetFloat("_CrackBlend", 1-enemyShield._healthbar.fillAmount );
       
    }

    private IEnumerator RefreshShieldCO()
    {
        yield return new WaitForSeconds(4f);
        SpawnShield();
        _shieldRefreshing = false;

    }

    private void RefreshShield()
    {
        if (!_shieldRefreshing)
        {
            _shieldRefreshing = true;
            StartCoroutine(RefreshShieldCO());
        }

        
    }

}
