using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] CookingEffectSounds = new AudioClip[2];
    public AudioClip[] CookingBackgroundSounds = new AudioClip[2];
    public GameObject[] cookAndOven = new GameObject[2];
    AudioSource myAudioSource;
    AudioSource myBackgroundSource;
    // Start is called before the first frame update
    void Start()
    {

    }
// Update is called once per frame
    void Update()
    {
        
    }
    
    public void setAudioSource(bool value,int index)
    {
        if(value)
        {
            if (index == 0) // cook
            {
                myAudioSource = cookAndOven[0].GetComponent<AudioSource>();
                myAudioSource.clip = CookingEffectSounds[0];
                myAudioSource.loop = false;
                myAudioSource.mute = false;
            }
            else if(index == 1) // oven
            {
                myAudioSource = cookAndOven[1].GetComponent<AudioSource>();
                myAudioSource.clip = CookingEffectSounds[1];
                myAudioSource.loop = false;
                myAudioSource.mute = false;
            }
        }
        else
        {
            if(index == 0)
            {
                myBackgroundSource = cookAndOven[0].GetComponent<AudioSource>();
                myBackgroundSource.clip = CookingBackgroundSounds[0];
                myBackgroundSource.loop = true;
                myBackgroundSource.mute = false;
            }
            else if(index == 1)
            {
                myBackgroundSource = cookAndOven[1].GetComponent<AudioSource>();
                myBackgroundSource.clip = CookingBackgroundSounds[1];
                myBackgroundSource.loop = true;
                myBackgroundSource.mute = false;
            }
        }
    }

    public AudioSource getAs()
    {
        return myAudioSource;
    }
    public AudioSource getBg()
    {
        return myBackgroundSource;
    }
}
