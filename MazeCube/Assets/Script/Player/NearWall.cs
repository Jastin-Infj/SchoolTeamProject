using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearWall : MonoBehaviour
{
    //プレイヤ追従時、プレイヤが隠れないよう壁を半透明にするスクリプト
    //-------------------------------------------------------------------------------------
    //PlayerCameraにアタッチしてください。
    //-------------------------------------------------------------------------------------
    // Ray
    protected Ray _ray;
    protected RaycastHit _rayhit;

    public Camera PlayerCamera; //プレイヤ表示用カメラ
    public GameObject Player;    //プレイヤ

    void Update()
    {
        _ray = new Ray(PlayerCamera.transform.position, -(PlayerCamera.transform.position - Player.transform.position));
        if (Physics.Raycast(_ray, out _rayhit))
        {
            if (_rayhit.collider.tag == "RayTarget")
            {
                // Ray が当たっている間は対象オブジェクトを非表示にする。
                _rayhit.collider.gameObject.SetActive(false);
            }
            else
            {
                // Ray が当たっていない時はオブジェクトを表示に戻す。
                _rayhit.collider.gameObject.SetActive(true);
            }
        }
    }
}