using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject spawnedfireball;
    private float BallSpeed = 50f;

    public void FireBall()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position,fireballtospawn.transform.rotation);
        spawnedfireball.GetComponent<Rigidbody>().velocity = transform.forward * BallSpeed;
        Destroy(spawnedfireball, 2f);
    }
    
}