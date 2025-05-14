using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    public LevelCompleteUI levelCompleted;
    //public GameOverController gameOverController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if(collision.gameObject.CompareTag("Player"))
       if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SoundManager.Instance.Play(Sounds.LevelComplete);
            Debug.Log("Level Over by player");
            LevelManager.Instance.MarkCurrentLevelComplete();
            levelCompleted.LevelComplete();
        }
    }
}
