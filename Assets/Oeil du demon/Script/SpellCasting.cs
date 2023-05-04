using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject spawnedfireball;
    private float BallSpeed = 40f;

    public void FireBall()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position,gameObject.transform.localRotation);
        spawnedfireball.GetComponent<Rigidbody>().velocity = transform.forward * BallSpeed;
        Destroy(spawnedfireball, 2f);
    }
    
    //add Slerp to curve the ball
    
}