using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPos : MonoBehaviour
{
    //PlayerCameraをPlayerに追従させるスクリプト
    //-------------------------------------------------------------------------------------
    //PlayerPosにアタッチしてください。
    //-------------------------------------------------------------------------------------
    //変数定義
    public GameObject objcamera; //プレイヤカメラ
    private GameObject obj;      //プレイヤキャラクタ

    void Start()
    {
        obj = this.objObjectFind(); //プレイヤの位置を取得
        objcamera.transform.Rotate(new Vector3(20, 0, 0)); //ｘ軸に20度傾ける。
        objcamera.transform.localScale = new Vector3(1, 1, 1); //プレイヤカメラのサイズ指定
    }

    void Update()
    {
        objcamera.transform.rotation = Quaternion.Euler(obj.transform.rotation.x, obj.transform.rotation.y, obj.transform.rotation.z);
        objcamera.transform.position = obj.transform.position;
        objcamera.transform.position += new Vector3(0, 0, -5);
    }

    private GameObject objObjectFind()
    {
        return GameObject.Find("Chara(Clone)");
    }
}


//if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Z)) //BボタンまたはキーボードZキーが押された場合
//         {
//            objPos.transform.rotation = obj.transform.rotation;  //プレイヤ向きを取得
//            this.transform.Rotate(new Vector3(90, 0, 0));
//         }
