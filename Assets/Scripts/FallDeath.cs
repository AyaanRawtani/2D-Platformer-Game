using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDeath : MonoBehaviour
{
    public PlayerDeath playerDeath;
    public GameOverController gameOverController;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.gameObject.CompareTag("Player"))
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("player fell");
            playerDeath.DecreaseLives(1);
            gameOverController.PlayerDied();
                    
        }
    }

  

}
