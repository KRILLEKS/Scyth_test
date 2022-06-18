using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class BackpackController : MonoBehaviour
{
   [SerializeField] private GameObject blockPrefabSerializable;
   [SerializeField] private GameObject backpackHolderSerializable;
   [SerializeField] private Vector3 startPosSerializable; // left bot block closest to players back
   [SerializeField] private float distanceSerializable;
   
   // public static variables
   public static readonly List<GameObject> _blocks = new List<GameObject>();

   // private static variables
   // I want to make them static cause it's inefficient to use Find method in every block
   private static GameObject _blockPrefab;
   private static GameObject _backpackHolder;
   private static Vector3 _startPos;
   private static float _distance;
   private static int _maxAmount;

   private void Awake()
   {
      _blockPrefab = blockPrefabSerializable;
      _backpackHolder = backpackHolderSerializable;
      _startPos = startPosSerializable;
      _distance = distanceSerializable;

      // to prevent possible issues
      _backpackHolder.transform.position = Vector3.zero;
      _maxAmount = Constants.backpackSize.x * Constants.backpackSize.y * Constants.backpackSize.z;
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

      _blocks[_blocks.Count - 1].transform.localPosition = _startPos + new Vector3((_blocks.Count - 1) % Constants.backpackSize.x * _distance,
                                                                                   (_blocks.Count - 1) / (Constants.backpackSize.x * Constants.backpackSize.z) * _distance,
                                                                                   -(_blocks.Count - 1) % (Constants.backpackSize.x * Constants.backpackSize.z) / Constants.backpackSize.z * _distance);
      _blocks[_blocks.Count - 1].transform.localRotation = Quaternion.identity;

      UIController.UpdateWheatInfo(_blocks.Count);
      return true;
   }

   // returns position of sold block
   // mb I shouldn't split this into 2 different methods I'm not sure about that
   public static Vector3 SellBlock()
   {
      GameObject block = _blocks[_blocks.Count - 1];
      _blocks.Remove(block);
      Destroy(block);
      UIController.UpdateWheatInfo(_blocks.Count);

      return block.transform.position;
   }

   private void OnDrawGizmos()
   {
      if (Application.isPlaying)
         return;

      for (int x = 0; x < Constants.backpackSize.x; x++)
         for (int y = 0; y < Constants.backpackSize.y; y++)
            for (int z = 0; z < Constants.backpackSize.z; z++)
            {
               Gizmos.DrawSphere(transform.position + startPosSerializable + new Vector3(x, y, -z) * distanceSerializable, 0.05f);
            }
   }
}