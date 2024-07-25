using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollect : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("TakeChild");
            
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.CollectChild();
        }
    }
}
