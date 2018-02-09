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
	// Use this for initialization
	void OnEnabled ()
	{
	}
	
	// Update is called once per frame
	public void Update ()
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
