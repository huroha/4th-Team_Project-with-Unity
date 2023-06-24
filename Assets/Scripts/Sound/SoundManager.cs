using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // �ֹ� ���� ����
    public AudioClip[] CookingEffectSounds = new AudioClip[2];
    public AudioClip[] CookingBackgroundSounds = new AudioClip[2];
    public GameObject[] cookAndOven = new GameObject[2];
    AudioSource myAudioSource;
    AudioSource myBackgroundSource;
    // ��� ���� ����
    public AudioClip slidingSound;
    AudioSource slidingSource;
    // �ȹ� ���� ����
    public GameObject innerObj;
    public AudioClip[] innerSound = new AudioClip[2]; // 0�� �к� , 1�� �̺� �����
    AudioSource innerSource;
    // �⺻���� �ý��� ����
    public GameObject door;
    public AudioClip doorSound;
    AudioSource doorSource;
    // ��� ����
    public AudioClip backgroundSound;
    AudioSource backgroundSource;
    // Start is called before the first frame update
    void Start()
    {
        setSource("background");
    }
// Update is called once per frame
    void Update()
    {
        
    }
    public void setSource(string name)
    {
        if(name == "door")
        {
            doorSource = door.GetComponent<AudioSource>();
            doorSource.clip = doorSound;
            doorSource.loop = false;
            doorSource.mute = false;
        }
        else if(name == "sliding")
        {
            slidingSource = GetComponent<AudioSource>();
            slidingSource.clip = slidingSound;
            slidingSource.loop = false;
            slidingSource.mute = false;
        }
        else if(name == "background")
        {
            backgroundSource = GameObject.Find("BGM").GetComponent<AudioSource>();
            backgroundSource.clip = backgroundSound;
            backgroundSource.loop = true;
            backgroundSource.mute = false;
            backgroundSource.Play();
        }
        else if(name == "torch")
        {
            innerSource = innerObj.GetComponent<AudioSource>();
            innerSource.clip = innerSound[0];
            innerSource.loop = false;
            innerSource.mute = false;
            innerSource.Play();
        }
        else if (name == "ebul")
        {
            innerSource = innerObj.GetComponent<AudioSource>();
            innerSource.clip = innerSound[1];
            innerSource.loop = false;
            innerSource.mute = false;
            innerSource.Play();
        }

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
    public AudioSource getDoor()
    {
        return doorSource;
    }
    public AudioSource getSliding()
    {
        return slidingSource;
    }
}
