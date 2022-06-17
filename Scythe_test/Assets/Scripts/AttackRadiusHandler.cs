using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadiusHandler : MonoBehaviour
{
   // we use separate class to trigger this event
   // and I don't make logic here cause It's incorrect to handle player attack in it's attack radius
   // It's more correct to handle it in player object and use cone radius only as a trigger
   // It's what I'm doing here 
   
   // also I use OnTriggerStay instead of OnTriggerEnter Because we anyway enters a lot of wheat fields
   // and with OnTriggerEnter bool variable in animator will be a bit chaotic
   // It will work but sometimes can cause error
   private void OnTriggerStay(Collider collideInfo)
   {
      if (collideInfo.CompareTag($"Wheat"))
         AttackController.StartAttackAnimation();
   }

   private void OnTriggerExit(Collider collideInfo)
   {
      if (collideInfo.CompareTag($"Wheat"))
         AttackController.StopAttackAnimation();
   }
}