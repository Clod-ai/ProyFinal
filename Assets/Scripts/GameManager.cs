using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float rotationYSensitivity = 1f;
    public float rotationXSensitivity = 1f;

    AudioManager audioManager;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void StartGame()
    {
        StartCoroutine(audioManager.StopSong(0, 2));
        StartCoroutine(audioManager.PlaySong(1, 2));
        SceneManager.LoadScene("Castle");
    }

}
