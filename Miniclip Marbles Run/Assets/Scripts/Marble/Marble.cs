using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Marble : MonoBehaviour
{
   public int ID;
   private Rigidbody rigidBody;
   public int NumLaps { get; set; } = 1;
   public int CurrentPos { get; set; } = 1;
   public Rigidbody Rigidbody => rigidBody;
   public Vector3 InitialPosition { get; set; }

   private void Awake()
   {
      rigidBody = GetComponent<Rigidbody>();
   }

   public int GetNumLaps()
   {
      return NumLaps;
   }

   public void AddLap()
   {
      NumLaps++;
   }
}
