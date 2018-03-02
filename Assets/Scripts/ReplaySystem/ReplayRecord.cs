using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayRecord : MonoBehaviour {

   public ReplayPlayer replayPlayer;
    List<Frame> frames;
    int maxFrame;
    int lenght;
    int frame_index;
    void Start () {
        //benim değiştirmem
        replayPlayer = FindObjectOfType<ReplayPlayer>();
        replayPlayer.Add(this);
        frames = new List<Frame>();
        maxFrame = replayPlayer.maxFrame;
        
	}

   
    void Update()
    { //if record add frame
        if (Game.GameMode == Game.GameModes.RECORD) { 
        Frame frame = new Frame(this.gameObject, transform.position, transform.rotation, transform.localScale);
        Add(frame);
    }
    }

    void Add(Frame _frame)
    {
        //add frame to frame list
        //if provide conditions
        if(lenght < maxFrame)
        {

        }else
        {
            frames.RemoveAt(0);
            lenght = maxFrame - 1;
        }

        frames.Add(_frame);
        lenght++;
    }
   
    public void Play()
    {
        // if frame not null
        //play the frame
        Frame frame;

        if((frame = GetFrame()) != null)
        {
            transform.position = frame.Position;
            transform.rotation = frame.Rotation;
            transform.localScale = frame.Scale;

        }
        else
        {
            Debug.Log("Replay is over");
            //DEBUG: Gamemode burada RECORD olabilir.
            Game.GameMode = Game.GameModes.RECORD;
        }

    }
    public void Clear()
    {
        frames.Clear();
    }

    Frame GetFrame()
    {
        frame_index++;
        //if pause stop time
        //not used
        if(Game.GameMode == Game.GameModes.PAUSE)
        {
            frame_index--;
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
        //if frame list is over then delete first one and add last one
        if(frame_index >= lenght)
        {

            Game.GameMode = Game.GameModes.RECORD;
            frame_index = lenght - 1;
            Debug.Log("Memory is over!");
        }

        //restriction 
        if (frame_index == -1)
        {
            frame_index = lenght-1;

        }
        return frames[frame_index];

    }

}
