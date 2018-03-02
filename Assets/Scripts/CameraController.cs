
using UnityEngine;

public class CameraController : MonoBehaviour {
    [Header("WhiteBallTransform")]
    public Transform whiteBall;
    [Header("Distance between camera and ball")]
    public int yDistance;
    public int zDistance;

    public GameObject go;

    public GameObject target;//the target object

    private float speedMod = 10.0f;//a speed modifier

    private Vector3 point;//the coord to the point where the camera looks at

    private bool mouseClickJudge = false;

    Rigidbody whiteRb;
   
    void Start () {
        //follow the white ball with main camera
        //old code 
        //transform.position = new Vector3(whiteBall.position.x,
        //                                 whiteBall.position.y + yDistance,
        //                                 whiteBall.position.z + zDistance);

        whiteRb = target.GetComponent<Rigidbody>();
    }
	
	
	void Update () {
        if (whiteRb.velocity != Vector3.zero)
        {    //FİXED : Çemberin açılarına göre ekranı ayarlamak gerekiyor.
            //z ekseninin sin ünü aldım. Kameranın etrafında döndüğü çemberin kameranın yaptığı 
            //açı ile kamerayı hareket ettirdim bu seferde ters açılarda oluyor.
            //->Açılar sin ve cos ile ilişkilendirildi eularAngles ile açılar belirtildi radyana çevirilerek sin ve cosun '-' olmamasından kurtarıldı.
            transform.position = new Vector3(whiteBall.position.x + zDistance * Mathf.Sin(Camera.main.transform.rotation.eulerAngles.y * Mathf.Deg2Rad), 
                                             whiteBall.position.y + yDistance ,
                                             whiteBall.position.z + zDistance * Mathf.Cos(Camera.main.transform.rotation.eulerAngles.y * Mathf.Deg2Rad));
            //Debug.Log(Mathf.Sin(Camera.main.transform.rotation.eulerAngles.y * Mathf.Deg2Rad));
            //Debug.Log(Mathf.Cos(Camera.main.transform.rotation.eulerAngles.y * Mathf.Deg2Rad));
            //Debug.Log(Camera.main.transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
        }


        if (whiteRb.velocity == Vector3.zero )
        {
            
            //if button pressed then do swiping or dont do anything
            if (Input.GetMouseButtonDown(0))
            {
                mouseClickJudge = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                mouseClickJudge = false;

            }
            if (mouseClickJudge)
            {
                transform.RotateAround(target.transform.position, 
                                        go.transform.up, 
                                        Input.GetAxis("Mouse X") * speedMod);
            }
        }
    }
}

