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

   // public static variables
   public static bool able2CutWheat; // if this is a true wheat can be cut when colliding with scythe
   
   // private static variables
   private static Animator _animator;
   
   // IDs
   private static readonly int Attack = Animator.StringToHash("ToAttack");
   
   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }
   
   // this method for animator
   // I want wheat be cut only after player starts attacking with scythe to make it looks better
   public void SetIsAttackingTrue()
   {
      able2CutWheat = true;
   }

   // this method for animator either
   // invokes at the end of the animation 
   public void SetIsAttackingFalse()
   {
      able2CutWheat = false;
   }

   public static void StartAttackAnimation()
   {
      _animator.SetBool(Attack, true);
   }

   public static void StopAttackAnimation()
   {
      _animator.SetBool(Attack, false);
   }
}
