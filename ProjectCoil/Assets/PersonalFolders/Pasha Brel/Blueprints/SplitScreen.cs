using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VR;

public class SplitScreen : MonoBehaviour
{
    /// <summary>
    /// In charge of switching from VR to split screen...
    /// 
    /// </summary>
    public event Action OnSplitEnable;
    public event Action OnSplitDisable;
   

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.A))
	    {
	        UnityEngine.XR.XRSettings.showDeviceView = false;
	        if (OnSplitEnable != null) OnSplitEnable();
	    }
	    if (Input.GetKeyDown(KeyCode.S))
	    {
	        UnityEngine.XR.XRSettings.showDeviceView = true;
	        if (OnSplitDisable != null) OnSplitDisable();
	    }

	    
    }

   
}
