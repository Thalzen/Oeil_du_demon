using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject spawnedfireball;
    private float BallSpeed = 40f;
    [SerializeField]private Transform[] TargetPos;
    
    
    public IEnumerator Fireball()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position,gameObject.transform.localRotation);
        yield return new WaitForSeconds(2f);
        
        Destroy(spawnedfireball, 2f);
    }

    private void Update()
    {
        if (spawnedfireball != null)
        {
            spawnedfireball.transform.position = Vector3.Slerp(TargetPos[0].position,TargetPos[1].position,0.5f);
        }
        
    }
}
