using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayPlayer : MonoBehaviour {
   
    List<ReplayRecord> replayRecords;
    public int maxFrame =100;

    void Awake() {
        replayRecords = new List<ReplayRecord>();
        Game.GameMode = Game.GameModes.RECORD;
    }


	void Start () {
       
	}
	
	
	void Update () {
        //if game mode record play replay record
        if (Game.GameMode != Game.GameModes.RECORD)
        {
            foreach (ReplayRecord rr in replayRecords)
            {
                rr.Play();
            }
        }
       

	}
     public void Pause()
    {
        Game.GameMode = Game.GameModes.PAUSE;
        Time.timeScale = 0f;

    }
    public void Play()
    {
        Game.GameMode = Game.GameModes.PLAY;
        Time.timeScale = 1f;
        

    }
    public void Exit()
    {
        Game.GameMode = Game.GameModes.RECORD;
        Time.timeScale = 1f;
    }
    public void Add(ReplayRecord rep)
    {
        replayRecords.Add(rep);
    }
   
   
}

public static class Game
{
    public static GameModes gameMode;
    public enum GameModes
    {
        PLAY,RECORD,PAUSE

    }

    public static GameModes GameMode
    {
        get
        {
            return gameMode;
        }

        set
        {

            gameMode = value;
          
        }

    }

}
