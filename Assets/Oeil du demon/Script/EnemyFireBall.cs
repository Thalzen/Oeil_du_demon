using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class EnemyFireBall : MonoBehaviour
{
    [SerializeField]private float BallSpeed = 0.2f;
    [SerializeField]private float _time = 1f;
    [SerializeField]private float _rotationspeed = 5f;
    private GameObject _fireballprefab;
    [SerializeField] private float fireballanglex;
    
    
    private void Start()
    {
        _fireballprefab = gameObject.transform.GetChild(0).gameObject;


    }
    private void Update()
    {
        
    }

    public IEnumerator enemyfireballmove(Transform target)
    {
        yield return new WaitForSeconds(2f);
        _fireballprefab.GetComponent<VisualEffect>().playRate = 4f;
        _fireballprefab.transform.rotation = Quaternion.Euler(-90f,0,0);
        gameObject.transform.localRotation = Quaternion.Euler(Random.Range(160,220), Random.Range(-30,30),0f);
        //gameObject.transform.localRotation = Quaternion.Euler(fireballanglex, fireballangley,0f);
        for (int i = 0; i < 1000f; i++)
        {
            _time = Time.deltaTime;
            Debug.DrawRay(transform.position,transform.forward*10f,Color.blue);
            transform.position += transform.forward * BallSpeed;
            transform.forward = Vector3.Slerp(transform.forward,target.position-transform.position,_rotationspeed*_time);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
