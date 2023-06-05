using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    [SerializeField] private GameObject fireballtospawn;
    private GameObject playerfireball;
    [SerializeField]private Transform[] PlayerTargetPos;
    private GameObject spawnedfireball;
    [SerializeField] private GameObject _shield;
    private bool shieldup;

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

    //playerpos[0] = playerpos
    //playerpos[1] = enemypos
    private void Fireball()
    {
        spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position,Quaternion.identity);
        spawnedfireball.GetComponent<PlayerFireBall>().givelocation(PlayerTargetPos[0],PlayerTargetPos[1]);
        //StartCoroutine(gatlingfireball());
    }

    private void Shield()
    {
        PlayerShield playerShield = _shield.GetComponent<PlayerShield>();
        _shield.SetActive(true);
        playerShield.HP = 30f;
        playerShield._healthbar.fillAmount = playerShield.HP / playerShield.MAXHP;
        
    }
    // public IEnumerator gatlingfireball()
    // {
    //     spawnedfireball = Instantiate(fireballtospawn, gameObject.transform.position,Quaternion.identity);
    //     spawnedfireball.GetComponent<PlayerFireBall>().StartCoroutine(spawnedfireball.GetComponent<PlayerFireBall>().playerfireballmove(PlayerTargetPos[1]));
    //     yield return new WaitForSeconds(0.2f);
    // }



}