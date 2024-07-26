using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Instances
    
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    public UnityEvent onGameOver = new UnityEvent();
    public UnityEvent onPlay = new UnityEvent();

    private bool IsPlaying;

    // Update is called once per frame
    void Update()
    {
        if(!IsPlaying)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        onPlay.Invoke();
        IsPlaying = true;
    }

    public void GameOver()
    {
        onGameOver.Invoke();
        IsPlaying=false;
    }
}
