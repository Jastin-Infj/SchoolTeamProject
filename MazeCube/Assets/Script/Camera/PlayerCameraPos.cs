using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPos : MonoBehaviour
{
    //PlayerCameraをPlayerに追従させるスクリプト
    //-------------------------------------------------------------------------------------
    //PlayerCameraにアタッチしてください。
    //-------------------------------------------------------------------------------------
    //変数定義
    public GameObject Player;       //プレイヤ
    public GameObject PlayerCamera; //プレイヤカメラ

    // Use this for initialization
    void Start()
    {
        PlayerCamera.transform.position = Player.transform.position + (new Vector3(0, 1, -4)); //プレイヤーカメラをプレイヤの座標の後ろ、上に設置。
        PlayerCamera.transform.Rotate(new Vector3(20, 0, 0)); //ｘ軸に20度傾ける。
    }
    void Update()
    {
        PlayerCamera.transform.position = Player.transform.position + (new Vector3(0, 1, -3f));
    }
}
