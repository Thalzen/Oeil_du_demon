// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Unity.Mathematics;
// using UnityEngine;
// using UnityEngine.XR;
// using UnityEngine.XR.Interaction.Toolkit;
//
// public class MovementRecognizerBackup : MonoBehaviour
// {
//     public XRNode inputSource;
//     public InputHelpers.Button inputButton;
//     public float InputThreshold = 0.1f;
//     public Transform movementSource;
//
//     public float newPositionThresholdDistance = 0.05f;
//     public GameObject debugSpherePrefab;
//
//     private bool isMoving = false;
//     private List<Vector3> positionsList = new List<Vector3>();
//     private List<GameObject> Spheretodestroy = new List<GameObject>();
//
//     private void Update()
//     {
//         InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, InputThreshold);
//         
//         //Start the movement
//         if (!isMoving && isPressed)
//         {
//             StartMovement();
//         }
//         //Ending the movement
//         else if (isMoving && !isPressed)
//         {
//             EndMovement();
//         }
//         //Updating the movement
//         else if (isMoving && isPressed)
//         {
//             UpdateMovement();
//         }
//     }
//
//     void StartMovement()
//     {
//         
//         isMoving = true;
//         positionsList.Clear();
//         positionsList.Add(movementSource.position);
//          
//         Spheretodestroy.Add(Instantiate(debugSpherePrefab, movementSource.position, quaternion.identity)); 
//     }
//
//     void EndMovement()
//     {
//         foreach (GameObject gameObject in Spheretodestroy)
//         {
//             Destroy((gameObject),1);
//         }
//         Spheretodestroy.Clear();
//         isMoving = false;
//     }
//
//     void UpdateMovement()
//     {
//
//         Vector3 lastPosition = positionsList[positionsList.Count - 1];
//         if (Vector3.Distance(movementSource.position,lastPosition) > newPositionThresholdDistance)
//         {
//             positionsList.Add(movementSource.position);
//             Spheretodestroy.Add(Instantiate(debugSpherePrefab, movementSource.position, quaternion.identity));
//         }
//         
//     }
// }
