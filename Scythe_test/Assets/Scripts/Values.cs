using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "Values", menuName = "ScriptableObjects/Values", order = 1)]
public class Values : ScriptableObject
{
   public float wheatRespawnTime = 10f; // in seconds
   public int3 backPackSize = new int3(4,5,4);
   public float coinFlySpeed = 250; // in meters
   public float sellSpeed = 10; // coins per second
   public float moneyPerOneCoin = 15;
}
