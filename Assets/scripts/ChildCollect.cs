using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollect : MonoBehaviour
{
    [SerializeField] private AudioClip screamSoundClip;
    [SerializeField] private AudioClip[] boneSoundClips;

    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SoundFXManager.instance.PlayRandomSoundFXClip(boneSoundClips, transform, 1f);
            SoundFXManager.instance.PlaySoundFXClip(screamSoundClip, transform, 1f);

            animator.SetTrigger("TakeChild");
            
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.CollectChild();
        }
    }
}
