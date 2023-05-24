using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SimpleLookat : MonoBehaviour
{
    private Transform lookatme;

    private void Start()
    {
        lookatme = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(lookatme);
    }
}
