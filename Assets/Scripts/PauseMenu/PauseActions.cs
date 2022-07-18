using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActions : MonoBehaviour
{
    AudioManager audioManager;
    GameManager gameManager;

    float rotationXSensitivity;
    float rotationYSensitivity;
    float musicVolume;
    float sfxVolume;

    private void Start()
    {
        audioManager = AudioManager.instance;
        gameManager = GameManager.instance;
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

    public void SaveChanges()
    {
        //gameManager.rotationXSensitivity = rotationXSensitivity;
        //gameManager.rotationYSensitivity = rotationYSensitivity;
        CameraController camController = Camera.main.gameObject.GetComponent<CameraController>();
        camController.SetXSens(rotationXSensitivity);
        camController.SetYSens(rotationYSensitivity);
        audioManager.AdjustMusicVolume(musicVolume);
        audioManager.AdjustSfxVolume(sfxVolume);
    }
}
