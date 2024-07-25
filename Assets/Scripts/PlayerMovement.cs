using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    [Header("Health")]
    public int health;

    [Header("Children collected")]
    public int children;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        // Gets all the information to send to the controller
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false; 
        }
        
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        //Sends the movement information to the character controller
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    //Health
    private int Health
    {
        get { return health; }
    }
    public void Damage()
    {
        if (health > 0)
        {
            health--;

            Debug.Log("AJ!");
        }
        else if (health == 0)
        {
            Destroy(gameObject); //TEMPORÄR

            Debug.Log("DÖD");

            //Helst när spelaren dör ska det komma ett GAME OVER, och att spelobjektet disablas.
            //LÄGG TILL DETTA!
        }
    }

    //Collectables
    public void CollectChild()
    {
        children++;
    }
}
