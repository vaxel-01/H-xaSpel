using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeChild : MonoBehaviour
{
    public Animator myAnimator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimator.SetTrigger("TakeChild");
        }
    }
}
