using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer effectMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetEffectVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        musicMixer.SetFloat("music", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetEffectVolume()
    {
        float volume = effectSlider.value;
        effectMixer.SetFloat("effect", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("effectVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        effectSlider.value = PlayerPrefs.GetFloat("effectVolume");

        SetMusicVolume();
        SetEffectVolume();
    }
}
