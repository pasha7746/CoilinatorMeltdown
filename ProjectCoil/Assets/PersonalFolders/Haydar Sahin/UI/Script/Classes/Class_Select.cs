using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ignoring until Pasha is here
/// </summary>
public class Class_Select : MonoBehaviour
{
    public Button button;
    
    public void OnEnable()
    {
        if (button != null)
        {
            button.onClick.AddListener(StorePlayer);
        }
    }

    private void StorePlayer()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
