using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Controller : MonoBehaviour
{

    void Update()
    {
        SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();

        if (controller != null && controller.menuPressed)
        {
            Pause.pause.PauseGame();
        }
    }
}
