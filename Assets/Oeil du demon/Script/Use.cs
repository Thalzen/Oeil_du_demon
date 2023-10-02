using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Use : MonoBehaviour
{
   public UnityEvent MethodToUse;

   public void UseMethod()
   {
      MethodToUse.Invoke();
   }
   
   
}
