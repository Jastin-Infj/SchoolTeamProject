using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraPos : MonoBehaviour
{
    //マップの中心にカメラコントローラーを置くスクリプト
    //-------------------------------------------------------------------------------------
    //Cameracontrollerにアタッチしてください。
    //-------------------------------------------------------------------------------------
    //変数定義
    public GameObject StagePos;     //適応したいステージをいれる
    public GameObject CameraController; //マップコントローラーをいれる

    // Use this for initialization
    void Start()
    {
        CameraController.transform.position = StagePos.transform.position; //カメラコントローラーとステージの中心の座標を同じにする。
    }
}
