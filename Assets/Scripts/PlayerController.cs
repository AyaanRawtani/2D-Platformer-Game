using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCol;

    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    private void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }

    public void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)                                                      //flipping the run dir
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        float VerticalInput = Input.GetAxis("Vertical");                           //vert input for Jump
        PlayJumpAnimation(VerticalInput);

        if (Input.GetKey(KeyCode.LeftControl))                                                  
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
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

   public void PlayJumpAnimation(float VerticalInput)
    {
        if (VerticalInput > 0)
        {
            animator.SetTrigger("Jump");
        }
    }
}
