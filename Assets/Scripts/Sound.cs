using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    public string name;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [Range(-1f, 1f)]
    public float stereoPan;

    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
