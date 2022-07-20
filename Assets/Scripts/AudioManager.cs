using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public float musicVolume = 0.8f;
    public float sfxVolume = 0.8f;

    public Sound[] songs;
    public Sound[] soundEffects;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in songs)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = musicVolume;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.pitch = s.pitch;
            s.source.panStereo = s.stereoPan;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySong(0, 5));
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void AdjustMusicVolume(float _musicVolume)
    {
        musicVolume = _musicVolume;
        foreach (Sound s in songs)
        {
            if (s.source) s.source.volume = musicVolume;
        }
    }

    public void AdjustSfxVolume(float _sfxVolume)
    {
        sfxVolume = _sfxVolume;
        foreach (Sound s in soundEffects)
        {
            if (s.source) s.source.volume = sfxVolume;
        }
    }

    public IEnumerator PlaySong(int number, float fadeTime)
    {
        AudioSource aS = songs[number].source;
        aS.volume = 0f;
        aS.Play();
        float currentTime = 0;
        float sourceVolume = 0f;
        while (currentTime < fadeTime)
        {
            aS.volume = Mathf.Lerp(sourceVolume, musicVolume, currentTime / fadeTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator StopSong(int number, float fadeTime)
    {
        AudioSource aS = songs[number].source;
        float currentTime = 0;
        float sourceVolume = aS.volume;
        while (currentTime < fadeTime)
        {
            aS.volume = Mathf.Lerp(sourceVolume, 0f, currentTime / fadeTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
        aS.Stop();
    }
}
