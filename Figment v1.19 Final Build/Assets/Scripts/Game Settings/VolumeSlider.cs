﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

    public Slider volumeSlider;

    public void Update()
    {
        AudioListener.volume = volumeSlider.value;
    }
}