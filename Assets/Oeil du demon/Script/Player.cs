using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Player : MonoBehaviour
{  
   
   [SerializeField] private float HP;
   [SerializeField] private float MAXHP;
   [SerializeField] private AudioClip oof;
   private AudioSource _audioSource;
   [SerializeField] private GameObject _vignette;
   public Volume volume;
   [SerializeField] private Image _healthbar;
   public UnityEvent GameOver;
   


   private void OnEnable()
   {
       volume.profile.components.ForEach(c => Debug.Log(c.GetType().Name)); 
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
       StartCoroutine(VignetteDamage());
       HP -= damage;
       if(_healthbar != null)
        _healthbar.fillAmount = HP / MAXHP;
       if (HP <= 0)
         GameOver.Invoke();
       
   }

   private IEnumerator VignetteDamage()
   {
       bool damagetaken = true;
       if (volume.profile.TryGet(out Vignette vignette) && damagetaken == true) // for e.g set vignette intensity to .4f
       {
           vignette.intensity.value = 0.4f;
           yield return new WaitForSeconds(0.03f);
           vignette.intensity.value = 0.6f;
           yield return new WaitForSeconds(0.03f);
           vignette.intensity.value = 0.8f;
           yield return new WaitForSeconds(0.03f);
           vignette.intensity.value = 1f;
           yield return new WaitForSeconds(0.03f);
           vignette.intensity.value = 0.8f;
           yield return new WaitForSeconds(0.03f);
           vignette.intensity.value = 0.6f;
           yield return new WaitForSeconds(0.03f);
           vignette.intensity.value = 0.4f;
           yield return new WaitForSeconds(0.03f);
           vignette.intensity.value = 0.22f;
           damagetaken = false;
       }
       
       
      
       
   }
}
