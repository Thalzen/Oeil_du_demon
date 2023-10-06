using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
   [SerializeField] private AudioSource _crowdSoundEffect;
   
    void Awake()
    {
        StartCoroutine(ChangeVolumeCoroutine());
    }
    

    private IEnumerator ChangeVolumeCoroutine()
    {
        yield return new WaitForSeconds(38f);
        _crowdSoundEffect.volume = 1f;
        yield return new WaitForSeconds(22f);
        _crowdSoundEffect.volume = 0.6f;
        yield return new WaitForSeconds(31f);
        _crowdSoundEffect.volume = 1f;
        yield return new WaitForSeconds(9f);
        _crowdSoundEffect.volume = 0.6f;
        StartCoroutine(ChangeVolumeCoroutine());
    }
    
    
    
}
