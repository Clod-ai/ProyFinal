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

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    /*void Start()
    {

    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
