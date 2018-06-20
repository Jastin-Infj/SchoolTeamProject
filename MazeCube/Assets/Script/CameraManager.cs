using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Camera GameStartCamera;      //ゲームスタート時のカメラ
    public Camera GetPoscamera;         //情報を取ってくるカメラ

    bool flag;
    // Use this for initialization
    void Start ()
    {
        this.GameStartCamera.enabled = true;
        this.GetPoscamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //キーボード「スペース」を押したら・・・・
		if(Input.GetKeyDown(KeyCode.Space))
        {
            //フラグを切り替える
            flag = !flag;
            CameraChange();
        }
	}
    private void CameraChange()
    {
        if (flag)
        {
            this.GameStartCamera.enabled = false;
            this.GetPoscamera.enabled = true;
        }
        else
        {
            this.GameStartCamera.enabled = true;
            this.GetPoscamera.enabled = false;
        }
    }
}
