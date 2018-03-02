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

    public float masterVolume { get; private set; }
    public float sfxVolume { get; private set; }
    public float MusicVolume { get; private set; }

    private AudioSource[] musicSound;
    private int currentMusicIndex = 0;

    public static Volume_Manager volumeBoss;
    private void Awake()
    {
        volumeBoss = this;
        musicSound = new AudioSource[2];
        for (int i = 0; i < 2; i++)
        {
            GameObject newMusic = new GameObject("Music" + i);
            musicSound[i] = newMusic.AddComponent<AudioSource>();
            newMusic.transform.parent = transform;
        }
    }

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
        PlayerPrefs.SetFloat("master_vol", 1);
        PlayerPrefs.SetFloat("music_vol", 1);
        PlayerPrefs.SetFloat("sfx_vol", 1);
    }

    public void PlayMusic(AudioClip musicClip, float fadeLength = 1)
    {
        if (musicClip != null)
        {
            currentMusicIndex = 1 - currentMusicIndex;
            musicSound[currentMusicIndex].clip = musicClip;
            musicSound[currentMusicIndex].Play();

            StartCoroutine(CrossFadeMusic(fadeLength));
        }
    }

    private IEnumerator CrossFadeMusic(float length)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / length;
            musicSound[currentMusicIndex].volume = Mathf.Lerp(0, MusicVolume * masterVolume, percent);
            musicSound[1-currentMusicIndex].volume = Mathf.Lerp(MusicVolume * masterVolume,0, percent);
            yield return null;
        }
    }

    public void PlaySfx(AudioClip sfxClip, Vector3 location)
    {
        if (sfxClip != null)
        {
            AudioSource.PlayClipAtPoint(sfxClip, location, sfxVolume * masterVolume);
        }
    }
}
