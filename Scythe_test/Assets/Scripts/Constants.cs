using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

// it's constants but from scriptable obj
public class Constants : MonoBehaviour
{
   public static float wheatRespawnTime; // in seconds
   public static int3 backpackSize;
   public static float coinFlySpeed; // in meters
   public static float sellSpeed; // coins per second
   public static float moneyPerOneCoin;

   private void Awake()
   {
      Values values = Resources.Load<Values>("Values");

      wheatRespawnTime = values.wheatRespawnTime;
      backpackSize = values.backPackSize;
      coinFlySpeed = values.coinFlySpeed;
      sellSpeed = values.sellSpeed;
      moneyPerOneCoin = values.moneyPerOneCoin;
   }
}
