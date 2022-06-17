using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadiusHandler : MonoBehaviour
{
   // we use separate class to trigger this event
   // and I don't make logic here cause It's incorrect to handle player attack in it's attack radius
   // It's more correct to handle it in player object and use cone radius only as a trigger
   // what I'm do here 
   private void OnTriggerEnter(Collider collideInfo)
   {
      if (collideInfo.CompareTag($"Wheat"))
         AttackController.InitializeAttack();
   }

   private void OnTriggerExit(Collider collideInfo)
   {
      if (collideInfo.CompareTag($"Wheat"))
         AttackController.StopAttack();
   }
}