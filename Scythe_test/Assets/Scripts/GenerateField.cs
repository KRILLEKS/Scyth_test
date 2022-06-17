using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GenerateField : MonoBehaviour
{
   [Header("Values")]
   [SerializeField] private Vector3 startPoint; // it's left bot corner of the field
   [SerializeField] private int2 size; // x*y = amount of wheat on the map
   [SerializeField] private float distance; // distance between wheat
   [Header("GOs")]
   [SerializeField] private GameObject prefab;
   [SerializeField] private GameObject wheatHolder; // will be set as parent to not overfill hierarchy with GOs
   
   private void Awake()
   {
      // to prevent possible issues
      wheatHolder.transform.position = Vector3.zero;

      // generate field
      for (int x = 0; x < size.x; x++)
         for (int y = 0; y < size.y; y++)
         {
            Instantiate(prefab, startPoint + new Vector3(x * distance, 0, y * distance), Quaternion.Euler(0,0,0), wheatHolder.transform);
         }
   }

   // to visualize field
   private void OnDrawGizmos()
   {
      // this gizmos useless in play mode
      // so there is no reason to show it
      if (Application.isPlaying)
         return;
      
      for (int x = 0; x < size.x; x++)
         for (int y = 0; y < size.y; y++)
         {
            Gizmos.DrawSphere(startPoint + new Vector3(x * distance, 0, y * distance), 0.3f);
         }
   }
}