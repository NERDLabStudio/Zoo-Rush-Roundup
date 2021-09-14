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
    int players;
    int count = 0;

    //might create a map (key: image (the character), value: number)
    //use a map to see what character was selected
    //public List of ints and go through 
    //size of list is the number of players


    public void Start()
    {
    }


    public void AssignCharacters() {
        Debug.Log("Player Selection");
        sceneToLoad = "RoundUpSettings";
        players = PlayerConfig.players2.Count;
        PlayerPrefs.SetInt("players", players);
        CharacterSelect[] characters = GetComponentsInChildren<CharacterSelect>();

        for(int i = 0; i < characters.Length; i++) {
            PlayerPrefs.SetInt("player" + i,characters[i].selectedCharacterIndex);
        }

        StartCoroutine(LoadAsyncScene());

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
        sceneToLoad = "PlayerSelection";
        //PlayerPrefs.SetString("mode", "roundup");
        StartCoroutine(LoadAsyncScene());
    }

    public void PlayerSelection()
    {
        //PlayerPrefs.DeleteAll();
        Debug.Log("Player Selection");
        sceneToLoad = "RoundUpSettings";
        //Figure out how many inputs there are
        players = PlayerConfig.players2.Count;
        PlayerPrefs.SetInt("players", players);
        //PlayerPrefs.SetString("mode", "roundup");
        /*for(int i = 0; i < players; i++){
            /*if(players == count){
                PlayerPrefs.SetInt("player" + count, CharacterSelect.selectedCharacterIndex);
                StartCoroutine(LoadAsyncScene());
            } else {
                PlayerPrefs.SetInt("player" + count, CharacterSelect.selectedCharacterIndex);
            }
            PlayerPrefs.SetInt("player" + i, GetComponentInChildren<CharacterSelect>().selectedCharacterIndex);
        }*/

        //GetComponent<CharacterSelect>().selectedCharacterIndex
        //count++;
        //Debug.Log("Count : " + count);
        StartCoroutine(LoadAsyncScene());
    }

    public void TimedRoundUp()
    {
        Debug.Log("Timed RoundUp, Here We Go!");
        sceneToLoad = "Zoo";
        PlayerPrefs.SetString("type", "timed");
        PlayerPrefs.SetInt("timer", 5);

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
        //PlayerPrefs.DeleteAll();
        Debug.Log("Starting The Chase!");
        sceneToLoad = "PlayerSelection";
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
