using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class PlayerFireBall : MonoBehaviour
{
    [SerializeField] public float _fireballdamage = 1f;
    [SerializeField] float InputThreshold = 0.1f;
    
    [SerializeField] private float BallSpeed = 0.2f;
    [SerializeField] private float _time = 1f;
    [SerializeField] private float _rotationspeed = 5f;
    private GameObject _fireballprefab;
    [SerializeField] private GameObject _enemyfireball;
    private Transform enemypostransfer;
    private Transform[] playerpostransfer;
    public bool Fired;
    private bool Countered;
    [SerializeField] private float fireballanglex;
    [SerializeField] private float fireballangley;
    [SerializeField] private GameObject fireballdirection;
    [SerializeField] private GameObject tinyExplosion;
    [SerializeField] private GameObject forceExplosion;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _pew;

    public delegate void DamageEvent(float damage);

    public static event DamageEvent DamageDealt;
    public static event DamageEvent EnemyShieldDamage;

    

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _fireballprefab = gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        // InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), InputHelpers.Button.Trigger, out bool isPressed, InputThreshold);
        // if (isPressed && !Countered && !Fired)
        // {
        //     Fired = true;
        //     StartCoroutine(playerfireballmove());
        // }
    }

    public IEnumerator playerfireballmove()
    {
        _fireballprefab.GetComponent<VisualEffect>().playRate = 4f;
        _fireballprefab.transform.rotation = Quaternion.Euler(-90,0,0);
        gameObject.transform.localRotation = Quaternion.Euler(Random.Range(-20,20), Random.Range(-50,50),0f);
        //_audioSource.PlayOneShot(_pew);
        //gameObject.transform.localRotation = Quaternion.Euler(fireballanglex, fireballangley,0f);
        //gameObject.transform.localRotation = Quaternion.Euler(fireballanglex, fireballangley,0f);
        for (int i = 0; i < 1000f; i++)
        {
            _time = Time.deltaTime;
            Debug.DrawRay(transform.position,transform.forward*10f,Color.blue);
            transform.position += transform.forward * BallSpeed;
            transform.forward = Vector3.Slerp(transform.forward,enemypostransfer.position-transform.position,_rotationspeed*_time);
            yield return new WaitForEndOfFrame();
        }
    }

    public void givelocation(Transform[] playerpos,Transform enemypos)
    {
        enemypostransfer = enemypos;
        playerpostransfer = playerpos;
    }

    //projectile being countered by the player
    public void playerprojectilecountered(bool countered, Transform enemypos, Transform[] playerpos)
    {
        playerpostransfer = playerpos;
        enemypostransfer = enemypos;
        Countered = countered;
        Fired = true;
        StartCoroutine(playerfireballmove());
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DamageDealt?.Invoke(_fireballdamage*10);
            Destroy(Instantiate(tinyExplosion,transform.position,quaternion.identity),2);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("EnemyShield"))
        {
            GameObject spawnfireball = Instantiate(_enemyfireball, gameObject.transform.position, quaternion.identity);
            spawnfireball.gameObject.GetComponent<EnemyFireBall>().enemyprojectilecountered(true,playerpostransfer,enemypostransfer);
            EnemyShieldDamage?.Invoke(_fireballdamage);
            Destroy(Instantiate(forceExplosion,transform.position,quaternion.identity),2);
            Destroy(gameObject);
        }
        // if (Random.Range(0, 100) >= 20)
        // {
        //     
        // }

    }
}
