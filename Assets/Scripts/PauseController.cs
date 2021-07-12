using System;
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

    public CanvasGroup gameScreen;
    public CanvasGroup pauseScreen;
    public CanvasGroup finishScreen;

    void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(gameScreen, screen == Screen.Game);
        Utility.SetCanvasGroupEnabled(pauseScreen, screen == Screen.Pause);
        Utility.SetCanvasGroupEnabled(finishScreen, screen == Screen.Finish);
    }

    void Start()
    {
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