using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Music : MonoBehaviour
{
    public AudioClip battleMusic;
    public GameObject BattleMusicGameObject;
    public GameObject relaxMusicGameObject;
    public AudioClip relaxMusic;
	// Use this for initialization
	void Start ()
	{
		Volume_Manager.volumeBoss.PlayMusic(battleMusic, 2);
        //relaxMusicGameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            Volume_Manager.volumeBoss.PlayMusic(relaxMusic, 2);
	        //BattleMusicGameObject.SetActive(true);
        }
	}
}
