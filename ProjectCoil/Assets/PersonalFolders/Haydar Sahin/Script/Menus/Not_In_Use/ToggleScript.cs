using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public event Action OnToggledOn;
    public event Action OnToggledOff;
	public Toggle myToggle;
	public Slider mySlider;
    public bool doseSliderChange;
	// Use this for initialization
	public void OnEnabled ()
    {
    }

    private void Update()
    {
        if (myToggle.isOn)
        {
            mySlider.value = 1;
            if (OnToggledOn != null)
            {
                OnToggledOn();
            }
        }
        else
        {
            mySlider.value = 0;
            if (OnToggledOff != null)
            {
                OnToggledOff();
            }
        }
    }
}
