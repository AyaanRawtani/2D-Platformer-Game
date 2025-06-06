using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PlayerDeath : MonoBehaviour
{
    private TextMeshProUGUI livesText;

    private int lives = 3;
    private void Awake()
    {
        livesText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshLives();
    }

    public void DecreaseLives(int decrement)
    {
        lives -= decrement;
        RefreshLives();
        
    }

    private void RefreshLives()
    {
        livesText.text = "Lives:" + lives;
    }


  

    public int getLives()
    {
        return lives;
    }

}
