using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonLobby;
    

    private void Awake()
    {
        buttonRestart.onClick.AddListener(Restart);
        buttonLobby.onClick.AddListener(Lobby);
    }

    private void Lobby()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        SoundManager.Instance.PlayBGMusic(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }

    public void Restart()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
