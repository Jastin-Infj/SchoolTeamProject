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
    public GameObject player;       //プレイヤ
    public GameObject playercamera; //プレイヤカメラ
    public GameObject PlayerPos;    //プレイヤ座標

    // Use this for initialization
    void Start()
    {
        PlayerPos.transform.position = player.transform.position;
        PlayerPos.transform.rotation = player.transform.rotation;
        playercamera.gameObject.transform.Translate(0, 1, -3); //プレイヤーカメラをプレイヤの座標の後ろ、上に設置。
        playercamera.transform.Rotate(new Vector3(20, 0, 0)); //ｘ軸に20度傾ける。
    }
    void Update()
    {

        PlayerPos.transform.position = player.transform.position;
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Z)) //BボタンまたはキーボードZキーが押された場合
        {
            PlayerPos.transform.rotation = player.transform.rotation;  //プレイヤ向きを取得
        }
    }
}
