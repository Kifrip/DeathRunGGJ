//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DeathSpikes : MonoBehaviour
//{
//    public ThirdPersonController playerController;

//    private void Start()
//    {
//        ThirdPersonController playerControllerScript = player.GetComponent<ThirdPersonController>();
//        playerControllerScript.publicVariable = newValue;
//    }
//    private void OnTriggerEnter(Collider collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            Debug.Log("IS DEAD");
//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class DeathSpikes : MonoBehaviour
{
    public GameObject player;
    private ThirdPersonController playerControllerScript;

    private void Start()
    {
        playerControllerScript = player.GetComponent<ThirdPersonController>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerControllerScript.isDead == false)
            {
                Debug.Log("OnTriggerEnter");
                playerControllerScript.isDead = true;
                playerControllerScript.TriggerDeath();
            }
        }
    }
}