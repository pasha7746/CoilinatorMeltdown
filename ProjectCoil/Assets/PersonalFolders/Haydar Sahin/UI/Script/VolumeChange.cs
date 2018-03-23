using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    public Slider volumeSlider;
    
    private Button button;

    [SerializeField] private float volumeAmount;
    // Use this for initialization
    public void OnEnable()
    {
        button = this.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(VolumeSliderChanger);
        }
    }

    private void VolumeSliderChanger()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value += volumeAmount;
            CheckVolume();
        }
        else
        {
            Debug.Log("Was there supposed to be sound. Sorry I forgot to slide it up");
        }
    }

    private void CheckVolume()
    {
        if (volumeSlider.value < 0)
        {
            volumeSlider.value = 0;
        }
        if (volumeSlider.value > 1)
        {
            volumeSlider.value = 1;
        }
    }
}
