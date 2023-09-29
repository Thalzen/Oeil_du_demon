using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Tutorial : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputLeft;
    public InputHelpers.Button inputRight;
    public float InputThreshold = 0.1f;
    private bool ButtonPressedLeft;
    private bool ButtonPressedRight;
    [SerializeField] private GameObject[] _sliderList;
    [SerializeField] private int slidernumber;


    private void Start()
    {
        _sliderList[0].SetActive(true);
    }

    private void Update()
    {
        
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputLeft, out bool isPressedLeft, InputThreshold);
        if (isPressedLeft && !ButtonPressedLeft)
        {
            ButtonPressedLeft = isPressedLeft;
            Debug.Log("Left");
            ChangeSliderLeft();
            
        }

        if (!isPressedLeft && ButtonPressedLeft) 
            ButtonPressedLeft = false;
        
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputRight, out bool isPressedRight, InputThreshold);
        if (isPressedRight && !ButtonPressedRight)
        {
            ButtonPressedRight = isPressedRight;
            Debug.Log("Right");
            ChangeSliderRight();
        }

        if (!isPressedRight && ButtonPressedRight) 
            ButtonPressedRight = false;
    }

    private void ChangeSliderRight()
    {
        _sliderList[slidernumber].SetActive(false);
        slidernumber++;
        if (slidernumber > 11)
            slidernumber = 11;
        if (!_sliderList[slidernumber].activeSelf)
            _sliderList[slidernumber].SetActive(true);

    }
    private void ChangeSliderLeft()
    {
        _sliderList[slidernumber].SetActive(false);
        slidernumber--;
        if (slidernumber < 0)
            slidernumber = 0;
        if (!_sliderList[slidernumber].activeSelf)
            _sliderList[slidernumber].SetActive(true);

    }
}
