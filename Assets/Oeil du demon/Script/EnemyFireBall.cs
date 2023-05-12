using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyFireBall : MonoBehaviour
{
    private float BallSpeed = 0.2f;
    private float _time = 0.01f;
    private float _rotationspeed = 0.1f;
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private void Update()
    {
        
    }

    public IEnumerator fireballmove(Transform target)
    {
        yield return new WaitForSeconds(2f);
        GetComponent<VisualEffect>().playRate = 4f;
        gameObject.transform.rotation = Quaternion.Euler(90f,0,0);
        for (int i = 0; i < 1000f; i++)
        {
            _time = Time.deltaTime;
            transform.position += transform.up * -BallSpeed;
            transform.up = Vector3.Slerp(transform.up,target.position-transform.position,_rotationspeed*_time);
            yield return new WaitForEndOfFrame();
        }
    }
}
