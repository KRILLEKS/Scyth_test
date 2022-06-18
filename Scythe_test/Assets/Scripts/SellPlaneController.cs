using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPlaneController : MonoBehaviour
{
   [SerializeField] private float sellSpeed; // blocks per second
   [SerializeField] private GameObject coinPrefab;
   [SerializeField] private GameObject coinsHolder;

   // private variables
   private Coroutine _sellCoroutine;

   private void Awake()
   {
      // to prevent possible issues
      coinsHolder.transform.position = Vector3.zero;
   }

   private void OnTriggerEnter(Collider triggerInfo)
   {
      if (triggerInfo.CompareTag($"Player") == false)
         return;
      
      _sellCoroutine = StartCoroutine(SellCoroutine());

      IEnumerator SellCoroutine()
      {
         while (BackpackController._blocks.Count > 0)
         {
            Instantiate(coinPrefab, BackpackController.SellBlock(), Quaternion.identity);
            yield return new WaitForSeconds(1 / sellSpeed);
         }

         _sellCoroutine = null;
      }
   }

   private void OnTriggerExit(Collider triggerInfo)
   {
      if (_sellCoroutine != null)
         StopCoroutine(_sellCoroutine);
   }
}