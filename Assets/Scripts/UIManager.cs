using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject Buttons, LoadingBar;

    public TextMeshProUGUI loadingPercentage;
    public Slider loadingBar;

    [SerializeField] int sceneIndex = 1;

    void Start()
    {
        Buttons.SetActive(true);
        LoadingBar.SetActive(false);
    }

    public void MainButtonPressed()
    {
        sceneIndex = 1;
        StartCoroutine(LoadAsync(sceneIndex));
    }

    public void HowToPlay()
    {
        sceneIndex = 2;
        StartCoroutine(LoadAsync(sceneIndex));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        Buttons.SetActive(false);
        LoadingBar.SetActive(true);

        float loading;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            loading = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.value = loading;

            loading *= 100;

            loadingPercentage.text = "Loading... " + loading.ToString() + "% done";

            yield return null;
        }
    }
}
