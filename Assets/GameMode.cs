﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    public string mode;
    public string type;
    public int timer;
    public int goal;
    public Text timeKeeper;
    public EmitterRandomizer masterEmitter;
    public Image winnerImage;
    public GameObject gameFinishedPanel;
    public Text finalScore;
    public GameObject winnerCanvas;
    private bool timedGame;
    private bool foundWinner = false;
    private int timeLeft;

    //List<GameObject> players;

    int playerCount;
    // Start is called before the first frame update
    void Start()
    {
        mode = PlayerPrefs.GetString("mode", "none");
        type = PlayerPrefs.GetString("type", "none");
        timer = PlayerPrefs.GetInt("timer", 0);
        timeLeft = (int)Time.time + timer;
        goal = PlayerPrefs.GetInt("goal", 0);
        if(timer > 0)
        {
            timedGame = true;
        }
        else
        {
            timedGame = false;
            timeKeeper.gameObject.SetActive(false);
        }

        playerCount = PlayerPrefs.GetInt("players", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //check for end of game
        //CHECK FOR TIMER
        if(timedGame)
        {
            int timeRemaining = (int)(timeLeft - Time.time);
            if(!foundWinner)
            {
                timeKeeper.text = timeRemaining.ToString("00");
            }
            if (Time.time >= timeLeft && !foundWinner)
            {
                Debug.Log("Times Up!");
                List<GameObject> players = Camera.main.GetComponent<FollowPlayers>().players;
                int mostAnimalsCaught = 0;
                int playerWithMostAnimals = 0;
                for(int i = 0; i < players.Count; i++)
                {
                    if(players[i].GetComponent<Player>().score.getPoints() > mostAnimalsCaught)
                    {
                        playerWithMostAnimals = i;
                        mostAnimalsCaught = players[i].GetComponent<Player>().score.getPoints();
                    }
                }
                winnerImage.sprite = players[playerWithMostAnimals].GetComponent<Player>().avatar;
                foundWinner = true;
                GameObject winnerScoreIcon = players[playerWithMostAnimals].GetComponent<Player>().scoreBox;
                GameObject winnerIcon = Instantiate(winnerScoreIcon);
                gameFinishedPanel.SetActive(true);
                winnerIcon.transform.parent = winnerCanvas.transform;
                winnerIcon.transform.position = new Vector3(320, 405, 0);
                winnerIcon.GetComponentInChildren<Text>().text = mostAnimalsCaught.ToString();
            }
        }
        else
        {
            if (!foundWinner)
            {
                //iterate through list of players to see if someone won
                GameObject winner = Camera.main.GetComponent<FollowPlayers>().whoWon();
                if (winner != null)
                {
                    foundWinner = true;
                    winnerImage.sprite = winner.GetComponent<Player>().avatar;
                    //end game
                    gameFinishedPanel.SetActive(true);

                }
            }
        }
    }
}
