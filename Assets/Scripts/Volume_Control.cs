using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume_Control : MonoBehaviour {

    public AudioMixer audioMixer;

    public void SetMusica (float volume)
    {
        audioMixer.SetFloat("Musica", volume);
    }
    public void SetSFX (float volume)
    {
        audioMixer.SetFloat("SFX", volume);
    }
}
