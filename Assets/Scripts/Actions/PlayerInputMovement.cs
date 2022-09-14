using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : MonoBehaviour
{
    PlayerInput controls;
    float direction = 0f;
    [SerializeField] float speed = 400;
    bool isFacingRight = true;

    [SerializeField] float jumpForce = 14f;
    bool IsGrounded;
    int numberOfJumps = 0;
    [SerializeField] Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] Animator animator;

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Awake(){
        controls = new PlayerInput();
        controls.Enable();

        controls.Player.Move.performed += ctx => {
            direction = ctx.ReadValue<float>();
        };

        controls.Player.Jump.performed += ctx => Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", IsGrounded);
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));
        if(isFacingRight && direction < 0 || !isFacingRight && direction > 0){
            Flip();
        }
    }

    void Flip(){
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump(){
       if(IsGrounded){
        numberOfJumps=0;
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        jumpSoundEffect.Play();
        numberOfJumps++;
       }
       else{
        if(numberOfJumps == 1){
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            jumpSoundEffect.Play();
            numberOfJumps++;
        }
       }
    }
}
