using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public LayerMask groundLayer;           

    public Transform groundCheck;           //Where we shooting from
    bool isFacingRight = true;

    RaycastHit2D raycastHit;


    private void Update()
    {
        raycastHit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayer);
    }

    private void FixedUpdate()
    {
        if(raycastHit.collider != false)
        {
            Debug.Log("Hitting ground");
            if(isFacingRight)
            {
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            }
        }
        else
        {
            Debug.Log("Not hitting");
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(-transform.localScale.x, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
}
