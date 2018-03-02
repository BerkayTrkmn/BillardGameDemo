using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAroundObject : MonoBehaviour {

    public GameObject target;//the target object
    private float speedMod = 10.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at
    private bool mouseClickJudge=false ;
    GameObject whiteBall;
    BallHitMovement bm;
    Rigidbody rb;
    void Start () {
        //point = target.transform.position;//get target's coords
        //transform.LookAt(point);//makes the camera look to it
        whiteBall = GameObject.Find("White");
        bm = whiteBall.GetComponent<BallHitMovement>();
        rb = whiteBall.GetComponent<Rigidbody>();
    }
	
	
	void Update () {
         
       

            
        //if button pressed then do swiping or dont do anything
        if (Input.GetMouseButtonDown(0) && rb.velocity == Vector3.zero) {
            mouseClickJudge = true;
        }
        if (Input.GetMouseButtonUp(0) && rb.velocity == Vector3.zero) {
            mouseClickJudge = false;
        }
        if (mouseClickJudge) {
            transform.RotateAround(target.transform.position, target.transform.up, Input.GetAxis("Mouse X") * speedMod);
        }
    }
}
