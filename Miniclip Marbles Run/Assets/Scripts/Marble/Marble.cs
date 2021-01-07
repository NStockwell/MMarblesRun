using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Marble : MonoBehaviour
{
   public int ID;
   private Rigidbody rigidBody;

   public Rigidbody Rigidbody => rigidBody;

   private void Awake()
   {
      rigidBody = GetComponent<Rigidbody>();
   }
}
