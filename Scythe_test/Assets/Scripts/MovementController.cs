using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
// must be attached to character
public class MovementController : MonoBehaviour
{
   // usually I separate input and movement
   // but cause we need input only in movement and project won't scale I won't do that
   [Header("Values")]
   [SerializeField, Range(2f,5f)] private float speed;
   [Header("Objects")]
   [SerializeField] private FloatingJoystick joystick;
   
   // private variables
   private Rigidbody _rigidbody;
   private Animator _animator;
   
   // IDs
   private static readonly int IsIdle = Animator.StringToHash("IsIdle");

   private void Awake()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _animator = GetComponent<Animator>();
   }

   private void FixedUpdate()
   {
      _rigidbody.velocity = new Vector3(joystick.Horizontal * speed, _rigidbody.velocity.y, joystick.Vertical * speed);

      if (joystick.Vertical != 0 || joystick.Horizontal != 0)
      {
         transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
         _animator.SetBool(IsIdle, false);
      }
      else
      {
         _animator.SetBool(IsIdle, true);
      }
   }
}
