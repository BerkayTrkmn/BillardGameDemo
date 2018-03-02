using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoad : MonoBehaviour {
    public PointController pc;
    

    public PlayerData playerData;

    private string filePath;
	
    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "data.json" );
        Load();
    }

	void Start () {
       
	}
	
	
	void Update () {
        //dont work
       // playerData = FindObjectOfType<PlayerData>();
	}

    void OnApplicationQuit()
    { 
        Save();
        Debug.Log("Saved");
    }

    void Save()
    {
        //Debug.Log(pc.highPoint);
        playerData.highScore = pc.highPoint;
        playerData.minTime = pc.minTime;
        playerData.maxHitCount = pc.maxHitCount;


        string jsonString = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, jsonString);
    }

    void Load()
    {
       


        string jsonString = File.ReadAllText(filePath);
        JsonUtility.FromJsonOverwrite(jsonString, playerData);

         pc.highPoint = playerData.highScore;
         pc.highPointText.text = playerData.highScore.ToString();

         pc.minTime = playerData.minTime;
         pc.minTimeText.text = playerData.minTime.ToString();

        pc.maxHitCount = playerData.maxHitCount;
        pc.maxHitCountText.text = playerData.maxHitCount.ToString();
    }
}
