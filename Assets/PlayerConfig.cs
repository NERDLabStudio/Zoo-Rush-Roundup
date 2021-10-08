using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerConfig : MonoBehaviour
{

    private List<PlayerSelection> players;
    //public GameObject player;
    public static List<PlayerSelect> players2;
    //public Button button;

    public Sprite[] characters;
    public Image selectedCharacter;
    public static int selectedCharacterIndex = 0;

    public static PlayerConfig Instance {
        get;
        private set;
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a seccond instance of a singleton class.");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            players = new List<PlayerSelection>();
            players2 = new List<PlayerSelect>();
        }
        
    }

    public void playerJoin(PlayerInput pi){
        pi.transform.SetParent(transform);

        //Debug.Log(pi.playerIndex);

        if(!players.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            players.Add(new PlayerSelection(pi));
        }

/*
        //if(players[pi.playerIndex] == 1){
            ColorBlock color = button.colors;
            color.selectedColor = new Color (255, 0, 0);
            button.colors = color;
            //player.GetComponent<Button>().SelectedColor = new Color (255, 0, 0);
        //}*/
    }

    public void playerJoin2(PlayerInput pi){
        pi.transform.SetParent(transform);

        if(!players2.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            players2.Add(new PlayerSelect(pi));
            //Debug.Log("INPUT: " + players2[0].Character);
        }
Debug.Log("TESTING: " + players2.Count());
        //GameObject gameObject = Instantiate(player);
    }


   
    
}


public class PlayerSelection {
    public PlayerSelection (PlayerInput input){
        PlayerIndex = input.playerIndex;
        Input = input;
    }

    public PlayerInput Input {
        get;
        private set;
    }
    public int PlayerIndex {
        get;
        private set;
    }
}


public class PlayerSelect {
    public PlayerSelect(PlayerInput input){
        PlayerIndex = input.playerIndex;
        Input = input;
    }

        public PlayerInput Input {
            get;
            private set;
        }
        public int PlayerIndex {
            get;
            private set;
        }
    }
