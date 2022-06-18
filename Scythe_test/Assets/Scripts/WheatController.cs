using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheatController : MonoBehaviour
{
   [SerializeField] private Mesh[] meshesArray;
   [SerializeField] private GameObject wheatBlockPrefab;

   // private variables
   private MeshFilter _meshFilter;
   private int _currentMeshIndex;
   private bool _isAble2TakeDamage = true; // after taking damage plant become invulnerable to prevent taking multiple hits
   private Coroutine _spawnCoroutine;

   private void Awake()
   {
      _meshFilter = GetComponentInChildren<MeshFilter>();
      _currentMeshIndex = meshesArray.Length - 1;
      _meshFilter.mesh = meshesArray[_currentMeshIndex];
   }

   private void OnTriggerEnter(Collider other)
   {
      if (AttackController.able2CutWheat && _currentMeshIndex > 0 && _isAble2TakeDamage)
      {
         _meshFilter.mesh = meshesArray[--_currentMeshIndex];
         _isAble2TakeDamage = false;
         // I didn't make any effects for that
         Instantiate(wheatBlockPrefab,
                     transform.position + new Vector3(Random.Range(-.3f, .3f), 1.5f, Random.Range(-.3f, .3f)),
                     quaternion.identity,
                     transform.parent); // goes into wheat holder
         
         StartCoroutine(InvulnerableCoroutine());

         _spawnCoroutine ??= StartCoroutine(SpawnCoroutine());
      }

      IEnumerator InvulnerableCoroutine()
      {
         yield return new WaitForSeconds(0.3f); // value doesn't really matter. It's approximate value
         _isAble2TakeDamage = true;
      }

      IEnumerator SpawnCoroutine()
      {
         while (_currentMeshIndex < meshesArray.Length - 1)
         {
            yield return new WaitForSeconds(Constants.wheatRespawnTime);
            _meshFilter.mesh = meshesArray[++_currentMeshIndex];
         }

         _spawnCoroutine = null;
      }
   }
}