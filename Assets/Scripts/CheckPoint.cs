using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Game : MonoBehaviour
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
            playerControllerScript.checkpointPosition = transform.position;
        }
    }
}
