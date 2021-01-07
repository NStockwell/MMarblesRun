using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Marble : MonoBehaviour
{
   public int ID;
   private Rigidbody rigidBody;
   public int NumLaps { get; set; } = 2;
   private Dictionary<Trigger, DateTime> _checkpoints = new Dictionary<Trigger, DateTime>();
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

   public Dictionary<Trigger, DateTime> GetCheckPoints()
   {
      return _checkpoints;
   }

   public void AddCheckpoint(Trigger trigger)
   {
      _checkpoints.Add(trigger, DateTime.Now);
   }
}
