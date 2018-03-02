using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour {

    RaycastHit hit;
    float distance;
    GameObject line;
    LineRenderer lr;
    public Vector3 forward;
    public GameObject raycastEnd;
   void Start()
    {
        line = new GameObject();
       //line.transform.parent = Camera.main.transform  ;
        line.transform.position = transform.position;
        line.AddComponent<LineRenderer>();
        lr = line.GetComponent<LineRenderer>();
        // forward = transform.TransformDirection(Vector3.forward) * 20;
        
    } 
	
	
	void Update () {
        //forward vector white ball goes
         forward = transform.TransformDirection(raycastEnd.transform.position) ;
        
       //line options
       // lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = Color.blue;
        lr.endColor = Color.red;
        lr.startWidth = 0.1f;
        lr.endWidth =0.1f;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1,  raycastEnd.transform.position );
        //line rotation
        // lr.transform.rotation =Camera.main.transform.rotation;
        raycastEnd.transform.rotation = Camera.main.transform.rotation;

        //raycast write distance and hit object
        //check raycast with debug
        //if (Physics.Raycast(transform.position, forward, out hit))
        //{
        //    distance = hit.distance;
        //    print(distance + "" + hit.collider.gameObject.name);
        //}
    }
}
