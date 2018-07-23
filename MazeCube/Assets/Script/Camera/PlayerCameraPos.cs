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
    private float interval = 0.01f;   //規定のタイム
    private float timeCnt = 0.01f;    //前フレームからのタイム取得

    public GameObject objcamera; //プレイヤカメラ
    public GameObject objPos;    //プレイヤ座標
    private GameObject obj;

    void Start()
    {
        obj = this.objObjectFind(); //プレイヤの位置を取得
        objcamera.transform.Rotate(new Vector3(20, 0, 0)); //ｘ軸に20度傾ける。
    }

    void Update()
    {
        timeCnt += Time.deltaTime;
        if (timeCnt >= interval) //規定のフレーム数が経過したら処理する
        {
            objPos.transform.position = obj.transform.position;
        
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Z)) //BボタンまたはキーボードZキーが押された場合
            {
                objPos.transform.rotation = obj.transform.rotation;  //プレイヤ向きを取得
                this.transform.Rotate(new Vector3(90, 0, 0));
            }
            timeCnt = 0;
        }
    }

    private GameObject objObjectFind()
    {
        return GameObject.Find("Chara(Clone)");
    }
}
