using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemySpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject Enemyfireball;
    private EnemyFireBall _enemyFireBall;
    public Transform[] EnemyTargetPos;
    private GameObject spawnedfireball;

    private void Start()
    {
        
    }


    public void Fireball()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position, Quaternion.identity);
        spawnedfireball.GetComponent<EnemyFireBall>().StartCoroutine(spawnedfireball.GetComponent<EnemyFireBall>().fireballmove(EnemyTargetPos[1]));

    }

}
