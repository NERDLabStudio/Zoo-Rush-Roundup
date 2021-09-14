using System.Collections;
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
        Debug.Log("TIME LEFT = " + timeLeft);
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
        Debug.Log("playerCount = " + playerCount);
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
                Debug.Log(players.Count);
                int mostAnimalsCaught = 0;
                int playerWithMostAnimals = 0;
                for(int i = 0; i < players.Count; i++)
                {
                    Debug.Log("Player " + i + " points: " + players[i].GetComponent<Player>().score.getPoints());
                    if(players[i].GetComponent<Player>().score.getPoints() > mostAnimalsCaught)
                    {
                        playerWithMostAnimals = i;
                        mostAnimalsCaught = players[i].GetComponent<Player>().score.getPoints();
                    }
                }
                finalScore.text = "Most Animals Caught: " + mostAnimalsCaught;
                winnerImage.sprite = players[playerWithMostAnimals].GetComponent<Player>().avatar;
                foundWinner = true;
                gameFinishedPanel.SetActive(true);
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
