using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Music : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] music;
    private int currentMusicIndex = 0;

    // Use this for initialization
    void Start ()
	{
		Volume_Manager.volumeBoss.PlayMusic(music[0], 2);
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            currentMusicIndex = 1 - currentMusicIndex;
            Volume_Manager.volumeBoss.PlayMusic(music[currentMusicIndex], 2);
        }
	}
}
