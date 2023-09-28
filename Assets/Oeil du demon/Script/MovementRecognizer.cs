using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using PDollarGestureRecognizer;
using Point = System.Drawing.Point;
using System.IO;
using UnityEngine.Events;

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float InputThreshold = 0.1f;
    public GameObject movementSource;

    public float newPositionThresholdDistance = 0.05f;
    public GameObject debugSpherePrefab;
    public GameObject trail;
    public bool creationMode = true;
    public string newGestureName;
    private bool isMoving = false;

    public float recognitionThreshold = 0.94f;
    [SerializeField] private GestureList _GestureList;

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string> {}

    public UnityStringEvent OnRecognized;

    private List<Gesture> trainingSet = new List<Gesture>();
    private List<Vector3> positionsList = new List<Vector3>();
    private List<GameObject> Spheretodestroy = new List<GameObject>();
    private GameObject _spawnedTrail;

    private void Start()
    {
        // foreach (var item in _GestureList.trainingSetData)
        // {
        //     trainingSet.Add(item);
        //     
        // }
    }

    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, InputThreshold);

        //Start the movement
        if (!isMoving && isPressed)
        {
            StartMovement();
        }
        //Ending the movement
        else if (isMoving && !isPressed)
        {
            EndMovement();
        }
        //Updating the movement
        else if (isMoving && isPressed)
        {
            UpdateMovement();
        }
    }

    void StartMovement()
    {
        
        isMoving = true;
        positionsList.Clear();
        positionsList.Add(movementSource.transform.position);

        GameObject spawnedtrail; 
        _spawnedTrail = Instantiate(trail, movementSource.transform.position, quaternion.identity);
        _spawnedTrail.transform.parent = movementSource.transform;

        //Spheretodestroy.Add(Instantiate(debugSpherePrefab, movementSource.position, quaternion.identity)); 
    }

    void EndMovement()
    {
        // foreach (GameObject gameObject in Spheretodestroy)
        // {
        //     Destroy((gameObject));
        // }
        //Spheretodestroy.Clear();

        _spawnedTrail.transform.parent = null;
        Destroy(_spawnedTrail,1.5f);
        
        isMoving = false;
        PDollarGestureRecognizer.Point[] pointArray = new PDollarGestureRecognizer.Point[positionsList.Count];

        for (int i = 0; i < positionsList.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionsList[i]);
            pointArray[i] = new PDollarGestureRecognizer.Point(screenPoint.x, screenPoint.y, 0);
        }

        Gesture newGesture = new Gesture(pointArray);
        
        //Add a new gesture to training set
        if (creationMode)
        {
            newGesture.Name = newGestureName;
            //trainingSet.Add(newGesture);
            _GestureList.trainingSetData.Add(newGesture);

            // string fileName = Application.persistentDataPath + "/" + newGestureName + "xml";
            // GestureIO.WriteGesture(pointArray, newGestureName, fileName);
        }
        //Recognize
        else
        {
            Result result = PointCloudRecognizer.Classify(newGesture, _GestureList.trainingSetData.ToArray());
            Debug.Log(result.GestureClass + " " + result.Score);
            if (result.Score >= recognitionThreshold )
            {
                OnRecognized.Invoke(result.GestureClass);
                Debug.Log(result.GestureClass + result.Score);
            }
        }

    }

    void UpdateMovement()
    {

        Vector3 lastPosition = positionsList[positionsList.Count - 1];
        if (Vector3.Distance(movementSource.transform.position,lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.transform.position);
            //Spheretodestroy.Add(Instantiate(debugSpherePrefab, movementSource.position, quaternion.identity));
        }
        
    }
}
