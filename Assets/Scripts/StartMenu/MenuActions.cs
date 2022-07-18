using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    GameManager gameManager;
    AudioManager audioManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        audioManager = AudioManager.instance;
    }

    public void AdjustRotationXSensitivity(float _rotationXSensitivity)
    {
        gameManager.rotationXSensitivity = _rotationXSensitivity;
    }

    public void AdjustRotationYSensitivity(float _rotationYSensitivity)
    {
        gameManager.rotationYSensitivity = _rotationYSensitivity;
    }

    public void AdjustMusicVolume(float _musicVolume)
    {
        audioManager.musicVolume = _musicVolume;
    }

    public void AdjustSfxVolume(float _sfxVolume)
    {
        audioManager.sfxVolume = _sfxVolume;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Castle");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
