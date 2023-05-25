using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class PlayerFireBall : MonoBehaviour
{
    [SerializeField]private float BallSpeed = 0.1f;
    [SerializeField]private float _time = 0.01f;
    [SerializeField]private float _rotationspeed = 0.1f;
    private GameObject _fireballprefab;
    [SerializeField] private float fireballanglex = -90;
    [SerializeField] private float fireballangley = -90;

    private void Start()
    {
        _fireballprefab = gameObject.transform.GetChild(0).gameObject;


    }
    private void Update()
    {
        
    }

    public IEnumerator playerfireballmove(Transform target)
    {
        yield return new WaitForSeconds(2f);
        _fireballprefab.GetComponent<VisualEffect>().playRate = 4f;
        _fireballprefab.transform.rotation = Quaternion.Euler(-90,0,0);
        gameObject.transform.localRotation = Quaternion.Euler(Random.Range(-20,20), Random.Range(-50,50),0f);
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
