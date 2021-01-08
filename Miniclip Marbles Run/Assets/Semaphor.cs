using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaphor : MonoBehaviour
{
    public Material Green;
    public Material Red;
    
    public void GoRed()
    {
        GetComponent<MeshRenderer>().material = Red;
    }
    public void GoGreen()
    {
        GetComponent<MeshRenderer>().material = Green;
    }
}
