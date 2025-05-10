using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCol;

    public ScoreController scoreController;
    public PlayerDeath playerDeath;
    public GameOverController gameOverController;
   // public LevelOverController levelOverController;


    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    private Rigidbody2D rb2d;

    public float playerSpeed;
    public float playerJump;

    private bool isGrounded = false;

    
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical );

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
    }

    private void PlayMovementAnimation(float horizontal , float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)                                                      //flipping the run dir
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

       
        if (vertical > 0 && isGrounded == true )                                                              //jump
        {
            animator.SetBool("Jump", true);

        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        //horizontal - left-right
        Vector3 position = transform.position;
        position.x += horizontal * playerSpeed * Time.deltaTime;
        transform.position = position;

        //vert- jump
        if (vertical > 0 && isGrounded == true)
        { 
            rb2d.AddForce(new Vector2(0f, playerJump), ForceMode2D.Force);                
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.transform.tag == "platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.transform.tag == "platform")
        {  isGrounded = false;}
    }

    public void Crouch(bool crouch)
    {
        if (crouch == true)
        {
            float offX = 0.03588617f;
            float offY = 0.5778199f;

            float sizeX = 0.6468706f;
            float sizeY = 1.226415f;

            boxCol.size = new Vector2(sizeX, sizeY);
            boxCol.offset = new Vector2(offX, offY);
            
        }
        else
        {
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
            
        }
        animator.SetBool("Crouch", crouch);
    }

   public void PickUpKey()
    {
        Debug.Log("Player Picked up the key! ");
        scoreController.IncreaseScore(10);
    }

   public void KillPlayer()
    {
        Debug.Log("Player killed by enemy");
        playerDeath.DecreaseLives(1);
        if(playerDeath.getLives() <= 0)
        {
            gameOverController.PlayerDied();
            this.enabled = false;
        }
        
    }

  
}
