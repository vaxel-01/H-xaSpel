using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI childUI;
    public TextMeshProUGUI healthUI;

    public GameObject StartMenuUI;

    private void Start()
    {
        GameManager.Instance.onGameOver.AddListener(activeMenuUI);
    }
    
    public void PlayButtonHandler()
    {
        GameManager.Instance.StartGame();
    }

    public void activeMenuUI()
    {
        StartMenuUI.SetActive(true);
    }

    private void OnGUI()
    {
        childUI.text = PlayerMovement.playing.Children.ToString();
        healthUI.text = PlayerMovement.playing.Health.ToString();
    }
}
