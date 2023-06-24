using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundMixer : MonoBehaviour
{
    // 오디오 믹서
    public AudioMixer audioMixer;

    // 슬라이더
    public Slider bgmSlider;
    public Slider sfxSlider;
    // Start is called before the first frame update
    public void setBgmVolume()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
    }
    public void setSfxVolume()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value) * 20);
    }
}
