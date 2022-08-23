using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BGM_Controller : MonoBehaviour
{

    AudioSource bgm;
    public Slider volSlider;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        bgm = GetComponent<AudioSource>();
    }

    public void VolumeControll() 
    { 
        bgm.volume = volSlider.value;
    }
}
