using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] private Rigidbody2D rb2D;
    
    [Header("Movement")]
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float jumpingPower;
    private float horizontal;
    private float vertical;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Player - Walking
        horizontal = Input.GetAxis("Horizontal");

        //Player - Jumping
        if(Input.GetButtonDown("Jump") && IsGrounded()) //Spelaren kan bara hoppa om den nuddar marken
        {
            rb2D.velocity = new Vector2(horizontal * walkingSpeed, jumpingPower);
        }
        
        if(rb2D.velocity.y==0) //När spelaren nuddar marken
        {

        }

        //OBS!! Spelaren kan wall-slide:a just nu

        rb2D.velocity= new Vector2(horizontal * walkingSpeed, rb2D.velocity.y);
    }

    private void FixedUpdate()
    {
        
    }

    //Ground Check 
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

}
