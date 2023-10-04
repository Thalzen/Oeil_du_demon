using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{  
   
   [SerializeField] private float HP;
   [SerializeField] private float MAXHP;
   [SerializeField] private AudioClip oof;
   private AudioSource _audioSource;


   private void OnEnable()
   {
       _audioSource = GetComponent<AudioSource>();
       EnemyFireBall.PlayerDamage += TakingDamage;
       EnemyElecBall.PlayerDamage += TakingDamage;
   }

   private void OnDisable()
   {
       EnemyFireBall.PlayerDamage -= TakingDamage;
       EnemyElecBall.PlayerDamage -= TakingDamage;
   }

   private void TakingDamage(float damage)
   {
       //_audioSource.PlayOneShot(oof);
       HP -= damage;

   }
}
