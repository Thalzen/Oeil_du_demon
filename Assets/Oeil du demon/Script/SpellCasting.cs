using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject spawnedfireball;
    private float BallSpeed = 40f;
    [SerializeField]private Transform[] TargetPos;

    public void FireBall()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position,gameObject.transform.localRotation);
        spawnedfireball.transform.position = Vector3.Slerp(TargetPos[0].position,TargetPos[1].position,0.5f);
        //spawnedfireball.GetComponent<Rigidbody>().velocity = transform.forward * BallSpeed;
        Destroy(spawnedfireball, 4f);
    }
    
    //add Slerp to curve the ball
    
}