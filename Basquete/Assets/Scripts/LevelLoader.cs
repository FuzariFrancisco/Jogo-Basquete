using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public string nomeCena;

    private void Start()
    {
        StartCoroutine(LoadAsynchronously(nomeCena));
    }

    IEnumerator LoadAsynchronously(string nomeCena)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nomeCena);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {    
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }
}
