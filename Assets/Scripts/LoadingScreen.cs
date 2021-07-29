using System.Collections;
using Infra;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : SingletonMonoBehaviour<LoadingScreen>
{
    [SerializeField] private Image progressBar;
    private CanvasGroup canvasGroup;

    private new void Awake()
    {
        base.Awake();
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        Utility.SetCanvasGroupEnabled(canvasGroup, false);
    }

    IEnumerator AsyncLoadScene(string level)
    {
        Utility.SetCanvasGroupEnabled(canvasGroup, true);

        progressBar.fillAmount = 0.0f;
        yield return new WaitForSeconds(0.25f);
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        while (!operation.isDone)
        {
            progressBar.fillAmount = operation.progress;
            yield return null;
        }

        Utility.SetCanvasGroupEnabled(canvasGroup, false);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(AsyncLoadScene(sceneName));
    }
}
