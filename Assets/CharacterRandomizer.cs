using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterRandomizer : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    private int selectedCharacterIndex = 0;
    public PlayerInputManager manager;
    public FollowPlayers follower;
    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0; j < PlayerPrefs.GetInt("players", 0); j++){
            manager.playerPrefab = characterPrefabs[PlayerPrefs.GetInt("player" + j, 0)];
            Debug.Log("CR:" + PlayerPrefs.GetInt("player" + j, 0));
            manager.JoinPlayer();
        }
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        follower.players = new List<GameObject>();
        for (int i = 0; i < gos.Length; i++)
        {
            follower.players.Add(gos[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerJoined()
    {
        Debug.Log("NEW PLAYER JOINED");
        
        /*selectedCharacterIndex++;
        if(selectedCharacterIndex > characterPrefabs.Length)
        {
            selectedCharacterIndex = 0;
        }

        Debug.Log("Player " + selectedCharacterIndex + ": " + PlayerPrefs.GetInt("player" + selectedCharacterIndex, 0));
        //manager.playerPrefab = characterPrefabs[PlayerPrefs.GetInt("player" + selectedCharacterIndex)];
        Debug.Log("Player Count = " + PlayerPrefs.GetInt("players", 0));
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");


        for(int j = 0; j < PlayerPrefs.GetInt("players", 0); j++){
            manager.playerPrefab = characterPrefabs[PlayerPrefs.GetInt("player" + j, 0)];
            follower.players = new List<GameObject>();

            for (int i = 0; i < gos.Length; i++)
            {
                follower.players.Add(gos[i]);
            }
        }*/

        /*follower.players = new List<GameObject>();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < gos.Length; i++)
            {
                follower.players.Add(gos[i]);
            }
*/
    }
}
