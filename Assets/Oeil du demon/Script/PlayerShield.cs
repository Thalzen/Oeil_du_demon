using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerShield : MonoBehaviour
{
    float InputThreshold = 0.1f;
    public float HP = 10;
    public float MAXHP = 10;
    public Image _healthbar;
    private bool isPulsed;
    private bool ButtonPressed = false;
    [SerializeField] private AudioClip _parrysound;
    [SerializeField] private AudioSource _audioSource;
    private bool parrysoundisplaying;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnEnable()
    {
        EnemyFireBall.PlayerShieldDamage += TakingDamage;
        EnemyElecBall.PlayerShieldDamage += TakingDamage;
    }

    private void OnDisable()
    {
        EnemyFireBall.PlayerShieldDamage -= TakingDamage;
        EnemyElecBall.PlayerShieldDamage -= TakingDamage;
    }

    private void Update()
    {
        
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), InputHelpers.Button.Trigger, out bool isPressed, InputThreshold);
        if (isPressed && !isPulsed && !ButtonPressed)
        {
            isPulsed = true;
            ButtonPressed = isPressed;
            StartCoroutine(Pulse());
        }

        if (!isPressed && ButtonPressed) 
            ButtonPressed = false;

    }

    public void TakingDamage(float damage)
    {
        if(!isPulsed)
        {
            HP -= damage;
            _healthbar.fillAmount = HP / MAXHP;
        }

        if (HP <= 0f)
        {
            gameObject.SetActive(false);
        }
        
        
    }
    
    private IEnumerator Pulse()
    {
        yield return new WaitForSeconds(0.5f);
        isPulsed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("EnemyFireball") && !parrysoundisplaying)
        {
            parrysoundisplaying = true;
            StartCoroutine(playparrysound());
        }
    }

    private IEnumerator playparrysound()
    {
        _audioSource.PlayOneShot(_parrysound);
        yield return new WaitForSeconds(0.3f);
        parrysoundisplaying = false;
    }
}
