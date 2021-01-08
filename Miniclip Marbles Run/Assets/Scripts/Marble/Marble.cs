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
   public float sideDamp = 0.1f;
   public float frontDamp = 0.2f;

   public Material innerMaterial;
   public MeshRenderer innerMeshRenderer;


   private void OnValidate()
   {
      innerMeshRenderer.material = innerMaterial;
   }

   private void Awake()
   {
      rigidBody = GetComponent<Rigidbody>();
      innerMeshRenderer.material = innerMaterial;
   }

   private void LateUpdate()
   {
      innerMeshRenderer.gameObject.transform.rotation = transform.rotation;
   }

   public int GetNumLaps()
   {
      return NumLaps;
   }

   public void AddLap()
   {
      NumLaps++;
   }

   public void ApplyLeftImpulse()
   {
      var rotatedVector = Quaternion.Euler(0, -90, 0) * rigidBody.velocity;
      Debug.Log($"apply impulse left {rotatedVector}");
      rigidBody.AddForce(rotatedVector*sideDamp, ForceMode.Impulse);  
   }

   public void ApplyRightImpulse()
   {
      var rotatedVector = Quaternion.Euler(0, 90, 0) * rigidBody.velocity;
      Debug.Log($"apply impulse right {rotatedVector}");
      rigidBody.AddForce(rotatedVector*sideDamp, ForceMode.Impulse);
   }

   public void ApplySpeedImpulse()
   {
      Debug.Log($"apply impulse speed {rigidBody.velocity}");
      rigidBody.AddForce(rigidBody.velocity * frontDamp, ForceMode.Impulse);
   }

   public void ApplyBreakImpulse()
   {
      Debug.Log($"apply impulse break {-rigidBody.velocity}");
      rigidBody.AddForce(-rigidBody.velocity*frontDamp, ForceMode.Impulse);
   }
}
