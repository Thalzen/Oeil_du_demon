using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class PlayerFireBall : MonoBehaviour
{
    [SerializeField] public float fireballdamage = 10;
    [SerializeField] float InputThreshold = 0.1f;
    
    [SerializeField] private float BallSpeed = 0.1f;
    [SerializeField] private float _time = 0.01f;
    [SerializeField] private float _rotationspeed = 0.1f;
    [SerializeField] private GameObject _fireballprefab;
    private Transform targetpos;
    private bool Fired;
    private bool Countered;

    public delegate void DamageEvent(float damage);

    public static event DamageEvent DamageDealt;

    private void Start()
    {
        _fireballprefab = gameObject.transform.GetChild(0).gameObject;

    }

    private void Awake()
    {
        _fireballprefab = gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), InputHelpers.Button.Trigger, out bool isPressed, InputThreshold);
        if (isPressed && !Countered && !Fired)
        {
            Fired = true;
            StartCoroutine(playerfireballmove());
        }
    }

    public IEnumerator playerfireballmove()
    {
        _fireballprefab.GetComponent<VisualEffect>().playRate = 4f;
        _fireballprefab.transform.rotation = Quaternion.Euler(-90,0,0);
        gameObject.transform.localRotation = Quaternion.Euler(Random.Range(-20,20), Random.Range(-50,50),0f);
        //gameObject.transform.localRotation = Quaternion.Euler(fireballanglex, fireballangley,0f);
        for (int i = 0; i < 1000f; i++)
        {
            _time = Time.deltaTime;
            Debug.DrawRay(transform.position,transform.forward*10f,Color.blue);
            transform.position += transform.forward * BallSpeed;
            transform.forward = Vector3.Slerp(transform.forward,targetpos.position-transform.position,_rotationspeed*_time);
            yield return new WaitForEndOfFrame();
        }
    }

    public void givelocation(Transform playerpos,Transform enemypos)
    {
        targetpos = enemypos;
    }

    public void projectilecountered(bool countered, Transform enemypos)
    {
        targetpos = enemypos;
        Countered = countered;
        Fired = true;
        StartCoroutine(playerfireballmove());
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DamageDealt?.Invoke(fireballdamage);
            Destroy(gameObject);
        }
    }
}
