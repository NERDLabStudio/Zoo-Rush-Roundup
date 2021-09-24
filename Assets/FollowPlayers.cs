using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayers : MonoBehaviour
{
    public List<GameObject> players;
    public GameObject scorePanel;
    private float averageX;
    private float maxX;
    private GameObject maxPlayer;
    private float minX;
    private GameObject minPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count > 0)
        {

            averageX = 0;
            minX = players[0].transform.position.x;
            minPlayer = players[0];
            maxX = players[0].transform.position.x;
            maxPlayer = players[0];

            for (int i = 0; i < players.Count; i++)
            {
                float playerX = players[i].transform.position.x;
                averageX += playerX;
                minX = Mathf.Min(playerX, minX);
                if(minX == playerX){
                    minPlayer = players[i];
                }
                maxX = Mathf.Max(playerX, maxX);
                if(maxX == playerX){
                    maxPlayer = players[i];
                }
            }
            if(maxX - minX > 15){
                maxPlayer.GetComponent<Player>().moveSpeed = 0;
            } else {
                maxPlayer.GetComponent<Player>().moveSpeed = 3;
            }

            if(maxX - minX > 20){
                minPlayer.GetComponent<Transform>().transform.position = new Vector3(averageX, minPlayer.GetComponent<Transform>().transform.position.y, minPlayer.GetComponent<Transform>().transform.position.z);
            }
            averageX = averageX / players.Count;
            Vector3 newCameraPosition = transform.position;
            newCameraPosition.x = averageX;

            transform.position = newCameraPosition;
        }
    }

    public GameObject whoWon()
    {
        if(players.Count > 0)
        {
            for(int i = 0; i < players.Count; i++)
            {
                if(players[i].GetComponent<Player>().winner)
                {
                    Debug.Log("We found a winner!");
                    return players[i];
                }
            }
        }
        return null;
    }
}
