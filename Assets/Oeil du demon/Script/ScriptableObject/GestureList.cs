using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PDollarGestureRecognizer;
using Point = System.Drawing.Point;
using System.IO;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GestureListScriptableObject")]
public class GestureList : ScriptableObject
{
   [SerializeField]public List<Gesture> trainingSetData = new List<Gesture>();
}
