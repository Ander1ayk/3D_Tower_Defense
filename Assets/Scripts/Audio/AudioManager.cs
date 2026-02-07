using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("References")]
    [SerializeField] private AudioMixerGroup audioMixerSFX;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    public void PlaySFX(AudioClip clip, bool pitchRandom = true, float volume = 1f)
    {
        if(clip == null) return;    

        GameObject go = new GameObject("TempSFX: " + clip.name);
        AudioSource source = go.AddComponent<AudioSource>();

        source.clip = clip;
        source.outputAudioMixerGroup = audioMixerSFX;

        source.volume = volume;

        if(pitchRandom)
            source.pitch = Random.Range(0.8f, 1.2f);
        source.Play();
        Destroy(go, clip.length);
    }
}
