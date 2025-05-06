using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    

    private void Awake()
    {
        buttonRestart.onClick.AddListener(Restart);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
