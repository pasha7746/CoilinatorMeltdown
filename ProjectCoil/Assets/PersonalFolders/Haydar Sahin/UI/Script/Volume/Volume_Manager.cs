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
    private AudioSource sfx2DSource;
    private AudioSource[] musicSound;
    private int currentMusicIndex = 0;

    public static Volume_Manager volumeBoss;
    private void Awake()
    {
        if (volumeBoss != null)
        {
            Destroy(gameObject);
        }
        else
        {
            volumeBoss = this;
            musicSound = new AudioSource[2];
            for (int i = 0; i < 2; i++)
            {
                GameObject newMusic = new GameObject("Music" + i);
                musicSound[i] = newMusic.AddComponent<AudioSource>();
                newMusic.transform.parent = transform;
            }
            GameObject newsfx2DSource = new GameObject("2D_Sfx");
            sfx2DSource = newsfx2DSource.AddComponent<AudioSource>();
            newsfx2DSource.transform.parent = transform;

            masterVolume = PlayerPrefs.GetFloat("master_vol", masterVolume);
            MusicVolume = PlayerPrefs.GetFloat("music_vol", sfxVolume);
            sfxVolume = PlayerPrefs.GetFloat("sfx_vol", MusicVolume);
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

        musicSound[0].volume = MusicVolume * masterVolume;
        musicSound[1].volume = MusicVolume * masterVolume;
        
        PlayerPrefs.SetFloat("master_vol", masterVolume);
        PlayerPrefs.SetFloat("music_vol", MusicVolume);
        PlayerPrefs.SetFloat("sfx_vol", sfxVolume);
        PlayerPrefs.Save();
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
    public void Play2DSfx(AudioClip sfxClip)
    {
        if (sfxClip != null)
        {
            sfx2DSource.PlayOneShot(sfxClip, sfxVolume * masterVolume);
        }
    }
}
