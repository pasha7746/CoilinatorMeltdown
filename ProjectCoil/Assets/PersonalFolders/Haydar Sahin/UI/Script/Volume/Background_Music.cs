using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Music : MonoBehaviour
{
    public AudioClip battleMusic;
    public AudioClip relaxMusic;
	// Use this for initialization
	void Start ()
	{
		Volume_Manager.volumeBoss.PlayMusic(battleMusic, 2);
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            Volume_Manager.volumeBoss.PlayMusic(relaxMusic, 2);
        }
	}
}
