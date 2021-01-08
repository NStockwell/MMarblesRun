using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bumper : MonoBehaviour
{
   private Collider collider;

   private void Awake()
   {
      collider = GetComponent<Collider>();
   }

   public void Descend()
   {
      GetComponent<Renderer>().enabled = false;
      collider.enabled = false;
   }
}
