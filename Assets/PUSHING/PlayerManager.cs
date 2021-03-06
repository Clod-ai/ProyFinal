using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public GameObject finishUI;

    public void ShowFinishUI()
    {
        PauseMenu.gameIsPaused = true;
        finishUI.SetActive(true);
    }
}
