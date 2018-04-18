using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    private RectTransform myRectTransform;
    [SerializeField]
    private float speed;
    private void OnEnable()
    {
        myRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
	void Update ()
	{
        myRectTransform.Rotate(new Vector3(0,0,speed * Time.deltaTime));
	}
}
