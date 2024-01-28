using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision!!!!");
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger!");
    }
}
