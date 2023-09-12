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
    [SerializeField] private GameObject elecballtospawn;
    private GameObject playerfireball;
    private GameObject playerelecball;
    [SerializeField]private Transform[] playerTargetPos;
    [SerializeField] private Transform enemyPos;
    private GameObject spawnedfireball;
    private GameObject spawnedelecball;
    [SerializeField] private GameObject _shield;
    private bool shieldup;
    [SerializeField] private List<GameObject> listball;
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

        if (spell == "Elecball")
        {
            
            ElecBall();
        }

        if (spell == "Shield")
        {
            Shield();
        }

    }
    
    private void Fireball()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position,Quaternion.identity);
        listball.Insert(0,spawnedfireball);
        spawnedfireball.GetComponent<PlayerFireBall>().givelocation(playerTargetPos,enemyPos);

        //StartCoroutine(gatlingfireball());
    }
    
    private void ElecBall()
    {
        spawnedelecball = Instantiate(elecballtospawn, gameObject.transform.position,Quaternion.identity);
        listball.Insert(0,spawnedelecball);
        spawnedelecball.GetComponent<PlayerElecBall>().givelocation(playerTargetPos,enemyPos);

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
        if (listball.Count != 0)
        {
            for (int i = listball.Count-1; i >= 0; i--)
            {

                if (listball[i].tag == "PlayerElecball")
                {
                    if (listball[i].GetComponent<PlayerElecBall>().Fired == false)
                    {
                        listball[i].GetComponent<PlayerElecBall>().Fired = true;
                        listball[i].GetComponent<PlayerElecBall>().StartCoroutine(listball[i].GetComponent<PlayerElecBall>().playerfireballmove());
                        listball.RemoveAt(i);
                        yield return new WaitForSeconds(0.2f);
                    }
                    
                }

                else if (listball[i].tag == "PlayerFireball")
                {
                    if (listball[i].GetComponent<PlayerFireBall>().Fired == false)
                    {
                        listball[i].GetComponent<PlayerFireBall>().Fired = true;
                        listball[i].GetComponent<PlayerFireBall>().StartCoroutine(listball[i].GetComponent<PlayerFireBall>().playerfireballmove());
                        listball.RemoveAt(i);
                        yield return new WaitForSeconds(0.2f);
                    }
                    
                }
                
                
            
            }
            //listFireball.Clear();
        }
        isShooting = false;
    }
    
}