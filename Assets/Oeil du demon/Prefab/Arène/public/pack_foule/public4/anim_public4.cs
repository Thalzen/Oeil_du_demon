using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_public4 : MonoBehaviour
{
    public Material[] _Materials;
    public float framebrasenbas = 0.3f;

    public float frameanim = 0.08f;
    public float framebrasenlair = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delaybeforeanim1());
    }

    IEnumerator delaybeforeanim1()
    {
        yield return new WaitForSeconds(frameanim);
        gameObject.GetComponent<Renderer>().material = _Materials[0];
        
        yield return new WaitForSeconds(frameanim);
        gameObject.GetComponent<Renderer>().material = _Materials[1];

        yield return new WaitForSeconds(frameanim);
        gameObject.GetComponent<Renderer>().material = _Materials[2];
        
        yield return new WaitForSeconds(framebrasenlair);
        gameObject.GetComponent<Renderer>().material = _Materials[1];

        StartCoroutine(delaybeforeanim1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
