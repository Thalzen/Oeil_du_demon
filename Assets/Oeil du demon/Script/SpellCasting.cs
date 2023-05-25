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
        StartCoroutine(gatlingfireball());

    }

    public IEnumerator gatlingfireball()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position,Quaternion.identity);
            spawnedfireball.GetComponent<PlayerFireBall>().StartCoroutine(spawnedfireball.GetComponent<PlayerFireBall>().playerfireballmove(PlayerTargetPos[1]));
            yield return new WaitForSeconds(0.2f);
        }
    }
    
    
    
}