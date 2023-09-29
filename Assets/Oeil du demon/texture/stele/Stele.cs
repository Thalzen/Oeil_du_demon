using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class Stele : MonoBehaviour
{
    [SerializeField] private Texture[] emissivelist;
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float InputThreshold = 0.1f;
    private bool _Pressed;
    private bool _ButtonPressed;

    // private void Update()
    // {
    //     InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, InputThreshold);
    //     
    //     if (isPressed && !_Pressed)
    //     {
    //         _Pressed = isPressed;
    //         if (GetComponent<Renderer>().material.GetTexture("_EmissionMap").name == "Arena")
    //         {
    //             ChangeScene("Arena");
    //         }
    //         else if (GetComponent<Renderer>().material.GetTexture("_EmissionMap").name == "Quitter")
    //         {
    //             Application.Quit();
    //         }
    //         
    //         
    //         
    //     }
    //
    //     if (!isPressed && _Pressed) 
    //         _Pressed = false;
    // }

    public void ChangeEmissive(Texture texture)
    {
        GetComponent<Renderer>().material.SetTexture("_EmissionMap",texture);
    }

    public void ChangeScene(string Scenename)
    {
        SceneManager.LoadScene(Scenename);
    }
}
