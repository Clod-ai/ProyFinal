using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    GameManager gameManager;
    AudioManager audioManager;

    float rotationXSensitivity;
    float rotationYSensitivity;
    float musicVolume;
    float sfxVolume;

    public GameObject settingsHolder;

    private void Start()
    {
        gameManager = GameManager.instance;
        audioManager = AudioManager.instance;
        rotationXSensitivity = gameManager.rotationXSensitivity;
        rotationYSensitivity = gameManager.rotationYSensitivity;
        musicVolume = audioManager.musicVolume;
        sfxVolume = audioManager.sfxVolume;
    }

    public void AdjustRotationXSensitivity(float _rotationXSensitivity)
    {
        rotationXSensitivity = _rotationXSensitivity;
    }

    public void AdjustRotationYSensitivity(float _rotationYSensitivity)
    {
        rotationYSensitivity = _rotationYSensitivity;
    }

    public void AdjustMusicVolume(float _musicVolume)
    {
        musicVolume = _musicVolume;
    }

    public void AdjustSfxVolume(float _sfxVolume)
    {
        sfxVolume = _sfxVolume;
    }

    public void StartGame()
    {
        gameManager.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SaveChanges()
    {
        gameManager.rotationXSensitivity = rotationXSensitivity;
        gameManager.rotationYSensitivity = rotationYSensitivity;
        audioManager.AdjustMusicVolume(musicVolume);
        audioManager.AdjustSfxVolume(sfxVolume);
        settingsHolder.SetActive(false);
    }
}
