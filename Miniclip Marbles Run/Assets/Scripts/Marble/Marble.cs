using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Marble : MonoBehaviour
{
   public int ID;
   private Rigidbody rigidBody;
   private int numLaps { get; set; } = 1;

   public Rigidbody Rigidbody => rigidBody;

   private void Awake()
   {
      rigidBody = GetComponent<Rigidbody>();
   }

   public int GetNumLaps()
   {
      return numLaps;
   }

   public void AddLap()
   {
      numLaps++;
   }
}
