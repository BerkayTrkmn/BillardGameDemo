using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class PointController : MonoBehaviour {
    //all points are controlled by this script

    [Header("Texts")]
    public Text pointText;
    public Text timeText;
    public Text hitCountText;
    public Text maxHitCountText;
    public Text highPointText;
    public Text minTimeText;

    [Header("Variables")]
    public int highPoint;
    public int minTime;
    public int maxHitCount;
    public int EndGameScore=2;
    int hitCount;
    int point = 0;
    float timer ;
   
   public static bool redCollision = false;
    public static bool yellowCollision = false;

   

    Scene scene;

    private BallHitMovement ballHit;

    void Awake()
    {
    }


    void Start () {
        ballHit = FindObjectOfType<BallHitMovement>();
        //load with playerprefs
        //highPointText.text=LoadProgress("highPoint").ToString();
        //minTimeText.text = LoadProgress("minTime").ToString();
        //maxHitCountText.text = LoadProgress("maxHitCount").ToString();
        scene = SceneManager.GetActiveScene();
    }
	
	
	void Update () {

        if (Game.GameMode == Game.GameModes.RECORD)
        {
            if (scene.name == "GameScreen")
            {
                AddPoint();
                timeText.text = Timer().ToString();
                HitCountCatcher();

            }
            HighPointCatcher();
            MinTimeCatcher(EndGameScore);
            MaxHitCountCatcher(EndGameScore);
        }

    }
    
    void AddPoint()
    {
        if(redCollision== true && yellowCollision == true)
        {
            point++;

            redCollision = false;
            yellowCollision = false;
            pointText.text = point.ToString();
        }

    }
    void HitCountCatcher()
    { 
        
            hitCount = ballHit.hitCount;
            hitCountText.text = hitCount.ToString();
    }

    void MaxHitCountCatcher(int endScore)
    {
        if (hitCount > maxHitCount)
        {//maxhitcount if maxed give text this value
            maxHitCount = hitCount;
           //if game ends change text
            if(point == EndGameScore)
            maxHitCountText.text = maxHitCount.ToString();
        }
        //save with playerprefs
        //old code
       // SaveProgress("maxHitCount", maxHitCount);

    }

    //Yüksek puan yakalar
    void HighPointCatcher()
    {
        if(point > highPoint)
        {//highpoint give text
            highPoint = point;
            highPointText.text = highPoint.ToString() ;
        }
        //save with playerprefs
        //old code
       // SaveProgress("highPoint", highPoint);
        
    }
    void MinTimeCatcher(int endScore)
    {// Timer with int
     //if point smaller than endscore timer increase
     
        if (endScore > point) { 
            if(minTime > timer)
            {
             
            }
            else
            {
                minTime = Mathf.CeilToInt(timer);
                minTimeText.text = minTime.ToString();
            }
            
           
       }
       
    // if point increase X save timer
    if(point == endScore)
        {
          //old code
          // SaveProgress("minTime", minTime);
          
        }
       
    }
    //playerpref ile kayıt işlemi
    //denendi ancak json ile yapılması gerekiyor.
    public void SaveProgress(string saveName, int savedNumber)
    {
        PlayerPrefs.SetInt(saveName , savedNumber);
    }

    public int LoadProgress(string LoadName)
    {
        if (PlayerPrefs.HasKey(LoadName))
        {
            return PlayerPrefs.GetInt(LoadName);
        }
        return 0;
    }
    int Timer()
    {
        timer += Time.deltaTime;
       
       return Mathf.CeilToInt(timer);
    }

    void OnTriggerEnter(Collider other)
    { // if white do collision with red do this


        if(other.gameObject.name == "Red" )
        {
            redCollision = true;
            
            
            other.GetComponent<AudioSource>().volume = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            other.GetComponent<AudioSource>().Play();
        }
        if (other.gameObject.tag == "Yellow")
        {
            yellowCollision = true;
           
            other.GetComponent<AudioSource>().volume = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            other.GetComponent<AudioSource>().Play();
        }

    }





}
