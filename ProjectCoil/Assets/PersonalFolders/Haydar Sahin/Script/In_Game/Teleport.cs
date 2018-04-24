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
        Screen_Change.screenChange.OnFadeToBlack += DoTeleport;
        masterManager.mySpawnController.OnBarricadeComplete += ICanBeHit;
    }

    private void ICanBeHit()
    {
        gameObject.SetActive(true);
    }

    private void DoTeleport()
    {
        if (canTeleport)
        {
            player.transform.position = teleportObject.transform.position;
            player.transform.rotation = teleportObject.transform.rotation;
            canTeleport = false;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Projectile>() != null)
        {
            Screen_Change.screenChange.FadeToBlack();
            canTeleport = true;
        }
    }

    private void OnDisable()
    {
        Screen_Change.screenChange.OnFadeToBlack -= DoTeleport;
        masterManager.mySpawnController.OnBarricadeComplete -= ICanBeHit;
    }
}
