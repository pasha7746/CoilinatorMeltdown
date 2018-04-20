using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisColisionTest : MonoBehaviour
{
    //test
    private void OnCollisionEnter(Collision other)
    {
        DebrisSound.debrisSound.Timer(transform.position);
    }
}
