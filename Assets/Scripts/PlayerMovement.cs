using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region 
    public static PlayerMovement playing;
    private void Awake()
    {
        if(playing==null)
        {
            playing=this;
        }
    }
    #endregion
    
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    [Header("Health")]
    public int health;

    [Header("Children collected")]
    public int children;

    [Header("Game manager")]

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    
    void Start()
    {
        GameManager.Instance.onPlay.AddListener(PlayerGameStart);
    }
    
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
    public int Health
    {
        get { return health; }
    }
    public void Damage()
    {
        if (health > 1)
        {
            health--;

            Debug.Log("AJ!");
        }
        else
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        }
    }

    //Collectables
    public int Children
    {
        get { return children; }
    }

    public void CollectChild()
    {
        children++;
    }

    //Game Manager saker
    private void PlayerGameStart()
    {
        gameObject.SetActive(true);

        jump=false;
        crouch=false;
        
        health=3;
    }
}