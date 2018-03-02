using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallHitMovement : MonoBehaviour {


    public Slider powerSlider;
    public Button replaybutton;
    RaycastController rayCont;
    public float thrust;
    public GameObject whiteBall;
    public GameObject redBall;
    public GameObject yellowBall;
    Rigidbody rbw;
    Rigidbody rbr;
    Rigidbody rby;
    public GameObject hitDirection;

    public int hitCount = 0;


	void Start () {

        rbw = whiteBall.GetComponent<Rigidbody>();
        rbr = whiteBall.GetComponent<Rigidbody>();
        rby = whiteBall.GetComponent<Rigidbody>();
        

        rayCont =GetComponent<RaycastController>();
        gameObject.GetComponent<Rigidbody>();
        //maxspeed =powerSlider.maxValue;
	}
    //variables to charged shot
    float maxspeed =100f;
    bool charge =false;
    bool shooting= false;
    float shotPower = 0f;

    public static bool replayMode = false;

    void Update() {

        //if game mode record and balls is moving deactive replay button

        if (Game.GameMode == Game.GameModes.RECORD)
        {
            if (rbw.velocity != Vector3.zero || rby.velocity != Vector3.zero || rbr.velocity != Vector3.zero)
            {
                replaybutton.gameObject.SetActive(false);
               
            }
        }


        //if replay mod on then close replay mode and do record
            if (Game.gameMode == Game.GameModes.PLAY)
        {
            if (rbw.velocity != Vector3.zero || rby.velocity != Vector3.zero || rbr.velocity != Vector3.zero)
            {
                replaybutton.gameObject.SetActive(false);
                replayMode = true;
            }


            if (rbw.velocity == Vector3.zero && rby.velocity == Vector3.zero && rbr.velocity == Vector3.zero && replayMode ==true)
            {
                   Game.gameMode = Game.GameModes.RECORD;
                replayMode = false;
            }
           

        }

        //restriction hit only 3 balls is stopped
        if (rbw.velocity == Vector3.zero && rby.velocity == Vector3.zero && rbr.velocity == Vector3.zero)
        {
            PointController.redCollision = false;
            PointController.yellowCollision = false;
            
            replaybutton.gameObject.SetActive(true);
            

            if (!shooting && Input.GetKeyDown(KeyCode.Space))
            {
                charge = true;
            }
            if (!shooting && Input.GetKeyUp(KeyCode.Space))
            {
                charge = false;
                rbw.AddForce((hitDirection.transform.position - transform.position) * shotPower, ForceMode.Force);
                powerSlider.value = 0f;
                shotPower = 0f;
                hitCount++;
            }
            //if charge true ball iş charging
            if (charge == true)
            {
                Game.gameMode = Game.GameModes.RECORD;
                //charge with time
                shotPower += Time.deltaTime * 20;
                powerSlider.value = shotPower;
                //max speed restriction
                shotPower = Mathf.Clamp(shotPower, 0f, maxspeed);
                            }

        }
    }
    
    
}
