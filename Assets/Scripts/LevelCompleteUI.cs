//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class LevelCompleteUI : MonoBehaviour
//{
//    public Button buttonRestart;
//    public Button buttonLobby;

//    private void Awake()
//    {
//        buttonRestart.onClick.AddListener(Restart);
//        buttonLobby.onClick.AddListener(Lobby);
//    }

//    public void levelComplete()
//    {
//        gameObject.SetActive(true);
//    }

//    private void Lobby()
//    {
//        SceneManager.LoadScene(0);
//    }
//    public void Restart()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//    }
//}
