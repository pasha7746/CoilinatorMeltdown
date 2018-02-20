using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume_Manager : MonoBehaviour
{
    public enum AudioType
    {
        Master,
        Sfx,
        Music
    }

    private float masterVolume = 1.0f;
    private float sfxVolume = 1.0f;
    private float MusicVolume = 1.0f;

    public void SetVolume(float volume, AudioType type)
    {
        switch (type)
        {
            case AudioType.Master:
                masterVolume = volume;
                break;
            case AudioType.Music:
                MusicVolume = volume;
                break;
            case AudioType.Sfx:
                sfxVolume = volume;
                break;
        }
        PlayerPrefs.SetFloat("master_vol", masterVolume);
        PlayerPrefs.SetFloat("music_vol", MusicVolume);
        PlayerPrefs.SetFloat("sfx_vol", sfxVolume);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
