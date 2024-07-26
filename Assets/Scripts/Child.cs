using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onPlay.AddListener(ActivateChild);
        GameManager.Instance.onGameOver.AddListener(DeactivateChild);   
    }

    private void ActivateChild()
    {
        gameObject.SetActive(true);
    }
    private void DeactivateChild()
    {
        gameObject.SetActive(false);
    }
}
