using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour {
    //-------------------------------------------------------
    //仮のプレイヤ処理
    //-------------------------------------------------------

    public float movementSpeed; //ユニティ側で進む速度を指定
    public float jumpPower; //ユニティ側で上方向に進む速度を指定
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //wキーで前に進む
        {
            transform.position += transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S)) //sキーで後ろに進む
        {
            transform.position -= transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D)) //dキーで右に進む
        {
            transform.position += transform.right * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A)) //aキーで左に進む
        {
            transform.position -= transform.right * movementSpeed;
        }
        //if (Input.GetKey(KeyCode.Space)) //スペースを押している間上方向へに進む
        //{
        //    transform.position += transform.up * jumpPower;
        //}
        if (Input.GetKey(KeyCode.Z)) //Zを押すとプレイヤが1度ずつ回転
        {
            transform.Rotate(new Vector3(0, 0, 1));
        }
    }
}