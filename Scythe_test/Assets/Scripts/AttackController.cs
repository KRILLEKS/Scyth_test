using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attached to player
public class AttackController : MonoBehaviour
{
   // this mesh will be used as a collider
   [SerializeField] private Mesh attackMesh;
   [SerializeField] private Vector3 offset;
   
   // private static variables
   private static Animator _animator;
   
   // IDs
   private static readonly int Attack = Animator.StringToHash("ToAttack");

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   public static void InitializeAttack()
   {
      _animator.SetBool(Attack, true);
      Debug.Log("attack");
   }

   public static void StopAttack()
   {
      _animator.SetBool(Attack, false);
   }
}
