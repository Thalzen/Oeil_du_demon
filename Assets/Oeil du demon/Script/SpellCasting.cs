using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject playerfireball;
    [SerializeField]private Transform[] playerTargetPos;
    [SerializeField] private Transform enemyPos;
    private GameObject spawnedfireball;
    [SerializeField] private GameObject _shield;
    private bool shieldup;
    [SerializeField] private List<GameObject> listFireball;
    private const float InputThreshold = 0.1f;
    private bool isShooting;


    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), InputHelpers.Button.Trigger, out bool isPressed, InputThreshold);
        if (isPressed && !isShooting)
        {
            isShooting = true;
            StartCoroutine(Shootfireball());
        }
    }

   

    // list of spell
    public void SpellList(string spell)
    {
        if (spell == "Fireball")
        {
            Fireball();
        }

        if (spell == "Shield")
        {
            Shield();
        }

    }
    
    private void Fireball()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position,Quaternion.identity);
        listFireball.Insert(0,spawnedfireball);
        spawnedfireball.GetComponent<PlayerFireBall>().givelocation(playerTargetPos,enemyPos);

        //StartCoroutine(gatlingfireball());
    }

    private void Shield()
    {
        PlayerShield playerShield = _shield.GetComponent<PlayerShield>();
        _shield.SetActive(true);
        playerShield.HP = 30f;
        playerShield._healthbar.fillAmount = playerShield.HP / playerShield.MAXHP;
        
    }

    private IEnumerator Shootfireball()
    {
        if (listFireball.Count != 0)
        {
            for (int i = listFireball.Count-1; i >= 0; i--)
            {
                if (listFireball[i].GetComponent<PlayerFireBall>().Fired == false)
                {
                    listFireball[i].GetComponent<PlayerFireBall>().Fired = true;
                    listFireball[i].GetComponent<PlayerFireBall>().StartCoroutine(listFireball[i].GetComponent<PlayerFireBall>().playerfireballmove());
                    listFireball.RemoveAt(i);
                    yield return new WaitForSeconds(0.2f);
                }
            
            }
            //listFireball.Clear();
        }
        isShooting = false;
    }
    
}