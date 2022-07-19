using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public float musicVolume = 0.8f;
    public float sfxVolume = 0.8f;

    public AudioClip[] songs;

    private List<AudioSource> audioSourcesSongs = new List<AudioSource>();

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < songs.Length; i++)
        {
            audioSourcesSongs.Add(gameObject.AddComponent<AudioSource>());
            audioSourcesSongs[i].clip = songs[i];
            audioSourcesSongs[i].volume = musicVolume;
            audioSourcesSongs[i].loop = true;
            audioSourcesSongs[i].playOnAwake = false;
            audioSourcesSongs[i].pitch = 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Play(0);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void AdjustMusicVolume(float _musicVolume)
    {
        musicVolume = _musicVolume;
    }

    public void AdjustSfxVolume(float _sfxVolume)
    {
        sfxVolume = _sfxVolume;
    }

    public void Play(int number)
    {
        audioSourcesSongs[number].Play();
    }
}
