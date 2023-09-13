using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class EnemyElecBall : MonoBehaviour
{
    private float _elecballdamage = 1f;
    [SerializeField] private float BallSpeed = 0.2f;
    [SerializeField] private float _time = 1f;
    [SerializeField] private float _rotationspeed = 5f;
    private GameObject _elecballprefab;
    [SerializeField] private GameObject _playerelecball;
    private Transform[] playerpostranfer;
    private Transform enemypostransfer;
    private bool Countered;
    [SerializeField] private float fireballanglex;
    [SerializeField] private float fireballangley;
    [SerializeField] private GameObject tinyExplosion;
    [SerializeField] private GameObject forceExplosion;
    
    public delegate void DamageEvent(float damage);

    public static event DamageEvent PlayerShieldDamage;
    
    

    private void Awake()
    {
        //_elecballprefab = gameObject.transform.GetChild(0).gameObject;
        _elecballprefab = gameObject;
    }

    private void Update()
    {
        
    }

    public IEnumerator enemyfireballmove(Transform enemypos,Transform[] playerpos)
    {
        enemypostransfer = enemypos;
        playerpostranfer = playerpos;
        
        //_fireballprefab.GetComponent<VisualEffect>().playRate = 4f;
        gameObject.transform.rotation = Quaternion.Euler(0f,180,0);
        _elecballprefab.transform.rotation = Quaternion.Euler(90f,0f,0);
        gameObject.transform.localRotation = Quaternion.Euler(Random.Range(0,-90), Random.Range(90,270),0f);
        //gameObject.transform.localRotation = Quaternion.Euler(fireballanglex, fireballangley,0f);
        int selectedpos = Random.Range(0,4);
        for (int i = 0; i < 1000f; i++)
        {
            _time = Time.deltaTime;
            Debug.DrawRay(transform.position,transform.forward*10f,Color.blue);
            transform.position += transform.forward * BallSpeed;
            transform.forward = Vector3.Slerp(transform.forward,playerpos[selectedpos].position-transform.position,_rotationspeed*_time);
            yield return new WaitForEndOfFrame();
        }
    }
    //projectile being countered by the enemy
    public void enemyprojectilecountered(bool countered, Transform[] playerpos , Transform enemypos)
    {
        playerpostranfer = playerpos;
        enemypostransfer = enemypos;
        Countered = countered;
        StartCoroutine(enemyfireballmove(enemypostransfer,playerpostranfer));
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("PlayerShield"))
        {
           GameObject spawnelecball = Instantiate(_playerelecball, gameObject.transform.position, quaternion.identity);
           spawnelecball.gameObject.GetComponent<PlayerElecBall>().playerprojectilecountered(true,enemypostransfer,playerpostranfer);
           PlayerShieldDamage?.Invoke(_elecballdamage*10);
           Destroy(Instantiate(forceExplosion,transform.position,quaternion.identity),2);
           Destroy(gameObject);
            
        }
    }
}
