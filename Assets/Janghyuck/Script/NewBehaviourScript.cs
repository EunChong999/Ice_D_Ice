using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider volumeSlider;

    void Start()
    {
        // AudioSource 및 Slider 컴포넌트에 대한 참조를 가져옵니다.
        musicSource = GetComponent<AudioSource>();
        volumeSlider = GetComponent<Slider>();

        // 초기 볼륨 설정
        volumeSlider.value = musicSource.volume;

        // Slider의 값이 변경될 때 호출되는 이벤트를 등록합니다.
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    void UpdateVolume(float volume)
    {
        // Slider의 값에 따라 AudioSource의 볼륨을 조절합니다.
        musicSource.volume = volume;
    }
}
