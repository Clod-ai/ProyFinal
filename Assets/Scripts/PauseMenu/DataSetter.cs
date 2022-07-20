using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Types
{
    sliderX,
    sliderY,
    xText,
    yText,
    sliderMusicVolume,
    musicVolumeText,
    sliderSfxVolume,
    sfxVolumeText
}

public class DataSetter : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;

    public Types type;

    private void Start()
    {
        gameManager = GameManager.instance;
        audioManager = AudioManager.instance;
}

    private void OnEnable()
    {
        if (!gameManager) gameManager = GameManager.instance;
        if (!audioManager) audioManager = AudioManager.instance;
        GetAndSetData(type);
    }

    public void GetAndSetData(Types type)
    {
        switch (type)
        {
            case Types.sliderX:
                {
                    GetComponent<Slider>().value = gameManager.rotationXSensitivity;
                    break;
                }
            case Types.xText:
                {
                    GetComponent<Text>().text = gameManager.rotationXSensitivity.ToString("N2");
                    break;
                }
            case Types.sliderY:
                {
                    GetComponent<Slider>().value = gameManager.rotationYSensitivity;
                    break;
                }
            case Types.yText:
                {
                    GetComponent<Text>().text = gameManager.rotationYSensitivity.ToString("N2");
                    break;
                }
            case Types.sliderMusicVolume:
                {
                    GetComponent<Slider>().value = audioManager.musicVolume;
                    break;
                }
            case Types.musicVolumeText:
                {
                    GetComponent<Text>().text = audioManager.musicVolume.ToString("N2");
                    break;
                }
            case Types.sliderSfxVolume:
                {
                    GetComponent<Slider>().value = audioManager.sfxVolume;
                    break;
                }
            case Types.sfxVolumeText:
                {
                    GetComponent<Text>().text = audioManager.sfxVolume.ToString("N2");
                    break;
                }
        }
    }
}
