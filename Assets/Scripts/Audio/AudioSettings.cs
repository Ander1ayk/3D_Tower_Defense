using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;
    [Header("Sliders")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Master") && PlayerPrefs.HasKey("Music") && PlayerPrefs.HasKey("SFX"))
            LoadVolume();
        else
        {
            masterSlider.value = 0.75f;
            musicSlider.value = 0.75f;
            sfxSlider.value = 0.75f;
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFX", volume);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Music", volume);
    }
    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Master", volume);
    }
    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("Master", 0.75f);
        SetMasterVolume();
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.75f);
        SetMusicVolume();
        sfxSlider.value = PlayerPrefs.GetFloat("SFX", 0.75f);
        SetSFXVolume();
    }
}
