using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BackpackController : MonoBehaviour
{
   [SerializeField] private GameObject blockPrefabSerializable;
   [SerializeField] private GameObject backpackHolderSerializable;
   [SerializeField] private Vector3 startPosSerializable; // left bot block closest to players back
   [SerializeField] private float distanceSerializable;

   // private static variables
   // I want to make them static cause it's inefficient to use Find method in every block
   private static GameObject _blockPrefab;
   private static GameObject _backpackHolder;
   private static Vector3 _startPos;
   private static float _distance;
   private static int _maxAmount;
   private static List<GameObject> _blocks = new List<GameObject>();

   private void Awake()
   {
      _blockPrefab = blockPrefabSerializable;
      _backpackHolder = backpackHolderSerializable;
      _startPos = startPosSerializable;
      _distance = distanceSerializable;

      // to prevent possible issues
      _backpackHolder.transform.position = Vector3.zero;
      _maxAmount = Constants.BACKPACK_SIZE.x * Constants.BACKPACK_SIZE.y * Constants.BACKPACK_SIZE.z;
   }

   // true if able to add block
   public static bool AddBlock()
   {
      if (_blocks.Count >= _maxAmount)
         return false;

      _blocks.Add(Instantiate(_blockPrefab,
                              Vector3.zero, 
                              Quaternion.identity,
                              _backpackHolder.transform));

      _blocks[_blocks.Count - 1].transform.localPosition = _startPos + new Vector3((_blocks.Count - 1) % Constants.BACKPACK_SIZE.x * _distance,
                                                                                   (_blocks.Count - 1) / 16 * _distance,
                                                                                   -(_blocks.Count - 1) % 16 / 4 * _distance);
      _blocks[_blocks.Count - 1].transform.localRotation = Quaternion.identity;

      return true;
   }

   private void OnDrawGizmos()
   {
      if (Application.isPlaying)
         return;

      for (int x = 0; x < Constants.BACKPACK_SIZE.x; x++)
         for (int y = 0; y < Constants.BACKPACK_SIZE.y; y++)
            for (int z = 0; z < Constants.BACKPACK_SIZE.z; z++)
            {
               Gizmos.DrawSphere(transform.position + startPosSerializable + new Vector3(x, y, -z) * distanceSerializable, 0.05f);
            }
   }
}