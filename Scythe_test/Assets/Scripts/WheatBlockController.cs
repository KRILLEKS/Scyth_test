using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class WheatBlockController : MonoBehaviour
{
   // local variables
   private void Awake()
   {
      transform.DOMoveY(-0.3f, 1f).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
   }

   private void OnTriggerEnter(Collider collideInfo)
   {
      if (collideInfo.CompareTag($"Player"))
         if (BackpackController.AddBlock())
         {
            DOTween.Kill(transform);
            Destroy(gameObject);
         }
   }
}
