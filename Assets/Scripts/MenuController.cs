using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    enum Screen
    {
        Main,
        Levels,
        Settings
    }

    public CanvasGroup mainScreen;
    public CanvasGroup levelsScreen;
    public CanvasGroup settingsScreen;

    void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(levelsScreen, screen == Screen.Levels);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Settings);
    }

    void Start()
    {
        SetCurrentScreen(Screen.Main);
    }
    
    public void OpenLevels()
    {
        SetCurrentScreen(Screen.Levels);
    }


    public void StartLevel1()
    {
        SceneManager.LoadScene("Level-1");
    }
    
    public void StartLevel2()
    {
        SceneManager.LoadScene("Level-2");
    }

    public void OpenSettings()
    {
        SetCurrentScreen(Screen.Settings);
    }

    public void CloseChildScreen()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}