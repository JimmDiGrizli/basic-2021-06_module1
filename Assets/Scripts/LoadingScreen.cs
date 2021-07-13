using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    private CanvasGroup canvasGroup;
    public static LoadingScreen instance { get; private set; }
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
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

    public void LoadScene(string name)
    {
        StartCoroutine(AsyncLoadScene(name));
    }
}
