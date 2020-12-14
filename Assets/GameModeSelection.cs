using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameModeSelection : MonoBehaviour
{
    // Start is called before the first frame update
    private string sceneToLoad;


    public void Start()
    {
    }
    public void Again()
    {
        sceneToLoad = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        sceneToLoad = "Main";
        StartCoroutine(LoadAsyncScene());

    }
    public void StartRoundUp()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Starting Round Up!");
        sceneToLoad = "RoundUpSettings";
        PlayerPrefs.SetString("mode", "roundup");
        StartCoroutine(LoadAsyncScene());
    }

    public void TimedRoundUp()
    {
        Debug.Log("Timed RoundUp, Here We Go!");
        sceneToLoad = "Zoo";
        PlayerPrefs.SetString("type", "timed");
        PlayerPrefs.SetInt("timer", 60);

        StartCoroutine(LoadAsyncScene());

    }

    public void PointBasedRoundUp()
    {
        Debug.Log("Point based round up, here we go!");
        sceneToLoad = "Zoo";
        PlayerPrefs.SetString("type", "points");
        PlayerPrefs.SetInt("goal", 10);

        StartCoroutine(LoadAsyncScene());

    }

    public void StartTheChase()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Starting The Chase!");
        sceneToLoad = "Zoo";
        PlayerPrefs.SetString("mode", "chase");
        PlayerPrefs.SetInt("timer", 60);

        StartCoroutine(LoadAsyncScene());


    }
    IEnumerator LoadAsyncScene()
    {


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
