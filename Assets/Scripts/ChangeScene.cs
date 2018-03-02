using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    //isim ile level değiştirme
   //change level with name
	
	

    public void SceneChange (string _levelName)
    {
        SceneManager.LoadScene(_levelName);

    }


}
