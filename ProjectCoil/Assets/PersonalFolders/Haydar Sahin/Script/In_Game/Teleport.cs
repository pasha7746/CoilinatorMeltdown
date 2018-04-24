using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportObject;
    public bool canTeleport;
    
    public GameObject player;

    private void OnEnable()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DebrisColisionTest>() != null)
        {
            if (canTeleport)
            {
                player.transform.position = teleportObject.transform.position;
                player.transform.rotation = teleportObject.transform.rotation;
                canTeleport = false;
            }
        }
        
    }
}
