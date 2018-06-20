using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    //変数定義
    public Camera PlayerCamera; //プレイヤ表示用カメラ
    public Camera MapCamera;    //マップ表示用カメラ
    public GameObject Cameracontroller;    //カメラコントローラー
    // Use this for initialization
    void Start () {
		    MapCamera.enabled = false; //開始と同時にマップ表示カメラは無効化
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire3")) //spaceまたはジョイスティックボタン3（XboxコントローラーＹボタン）を押すと...
        {
            if (PlayerCamera.enabled == true)   //プレイヤカメラ無効、マップカメラ有効化
            {
                PlayerCamera.enabled = false;
                MapCamera.enabled = true;
            }
            else                                //マップカメラ無効、プレイヤカメラ有効化
            {
                MapCamera.enabled = false;
                PlayerCamera.enabled = true;
            }
        }
        if (MapCamera.enabled == true) //マップカメラが有効な時のみ...
        {
            if (Input.GetButtonDown("Fire1")) //left ctrlまたはジョイスティックボタン4（XboxコントローラーLBボタン）を押すと...
            {
                Cameracontroller.transform.Rotate(new Vector3(0, 45, 0));
            }
            if (Input.GetButtonDown("Fire2")) //left altまたはジョイスティックボタン5（XboxコントローラーRBボタン）を押すと...
            {
                Cameracontroller.transform.Rotate(new Vector3(0, -45, 0));
            }
        }
    }
}


