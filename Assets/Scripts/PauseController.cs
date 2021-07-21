using System;
using System.ComponentModel;
using Sound;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    enum Screen
    {
        Game,
        Pause,
        Finish
    }

    [SerializeField] private CanvasGroup gameScreen;
    [SerializeField] private CanvasGroup pauseScreen;
    [SerializeField] private CanvasGroup finishScreen;

    [SerializeField] private string loseSound;
    [SerializeField] private string winSound;
    private SoundPlayer soundPlayer;

    void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(gameScreen, screen == Screen.Game);
        Utility.SetCanvasGroupEnabled(pauseScreen, screen == Screen.Pause);
        Utility.SetCanvasGroupEnabled(finishScreen, screen == Screen.Finish);
    }

    void Start()
    {
        soundPlayer = GetComponent<SoundPlayer>();
        Game();
    }
    
    public void Pause()
    {
        SetCurrentScreen(Screen.Pause);
        Time.timeScale = 0.0f;
    }
    
    public void Game()
    {
        SetCurrentScreen(Screen.Game);
        Time.timeScale = 1.0f;
    }
    
    public void Finish(bool isPlayerWon)
    {
        if(soundPlayer) soundPlayer.Play(isPlayerWon ? winSound : loseSound);
        var text =  finishScreen.GetComponentInChildren<TextMeshProUGUI>();
        text.text = isPlayerWon ? "You won." : "You lose.";
        SetCurrentScreen(Screen.Finish);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}