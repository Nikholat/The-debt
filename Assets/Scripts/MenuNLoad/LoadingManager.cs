using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Image progressBar;

    int sceneNumberToLoad;

    public void LoadScene(int sceneNumber)
    {
        sceneNumberToLoad = sceneNumber;
        loadingScreen.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(LoadSceneProcess());
    }

    private IEnumerator LoadSceneProcess()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNumberToLoad);


        while (!asyncLoad.isDone)
        {
            progressBar.fillAmount = asyncLoad.progress;
            yield return null;
        }
    }
}
