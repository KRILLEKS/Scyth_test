using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ideally it should be split into 2 classes. Sell plane and money controller
// where money controller will handle all operations with money
public class SellPlaneController : MonoBehaviour
{
   [SerializeField] private GameObject coinPrefab; // 2d texture
   [SerializeField] private Canvas coinCanvas; // where to spawn coins 
   [SerializeField] private GameObject coinsHolder;
   [SerializeField] private GameObject coinIcon; // coins will fly to this icon

   // public static variables
   public static Vector3 coinIconPos;
   
   // private variables
   private Coroutine _sellCoroutine;
   private Camera _camera;

   private void Awake()
   {
      // to prevent possible issues
      coinsHolder.transform.position = Vector3.zero;
      _camera = FindObjectOfType<Camera>();
      coinIconPos = coinIcon.transform.position;
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
            Instantiate(coinPrefab, _camera.WorldToScreenPoint(BackpackController.SellBlock()), Quaternion.identity, coinCanvas.transform);
            yield return new WaitForSeconds(1 / Constants.sellSpeed);
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