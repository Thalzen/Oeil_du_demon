using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject playerfireball;
    [SerializeField]private Transform[] PlayerTargetPos;
    private GameObject spawnedfireball;

    public void FireBall()
    {
        playerfireball = Instantiate(fireballtospawn, gameObject.transform.position,gameObject.transform.localRotation);
        playerfireball.GetComponent<PlayerFireBall>().StartCoroutine(spawnedfireball.GetComponent<PlayerFireBall>().playerfireballmove(PlayerTargetPos[1]));
        
    }
    
    
    
}