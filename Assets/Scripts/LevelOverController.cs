using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if(collision.gameObject.CompareTag("Player"))
       if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Over by player");
        }
    }
}
