using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    //PlayerCameraとPlayerの間にオブジェクトがある場合PlayerにPlayerCameraを近づけるスクリプト
    //-------------------------------------------------------------------------------------
    //PlayerCameraにアタッチしてください。
    //-------------------------------------------------------------------------------------

    //　カメラの元の位置
    [SerializeField]
    private Vector3 cameraPrePosition;
    private Transform player;
    private RaycastHit hit;
    //　カメラの移動スピード
    [SerializeField]
    private float cameraMoveSpeed = 3f;

    void Start()
    {
        player = transform.root;
        //　初期位置を設定
        cameraPrePosition = transform.localPosition;
    }

    void Update()
    {
        //　カメラが障害物と接触してたら障害物の場所に移動
        if (Physics.Linecast(player.position + Vector3.up, transform.position, out hit, LayerMask.GetMask("Field")))//処理を行う場合の対象オブジェクトレイヤー名を入れる
        {
            transform.position = Vector3.Lerp(transform.position, hit.point, cameraMoveSpeed * Time.deltaTime);
            //　障害物と接触してなければ元のカメラ位置に移動
        }
        else
        {
            //　元の位置ではない時だけ元の位置に移動
            if (transform.localPosition != cameraPrePosition)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, cameraPrePosition, cameraMoveSpeed * Time.deltaTime);
            }
        }
    }
}